using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Resources;
namespace Covid_Web_API.Controllers
{
    public class CovidController : ApiController

    {
        private static readonly HttpClient client = new HttpClient();
         static ResourceManager resourceManager = new ResourceManager("Covid_Web_API.Resource", typeof(Program).Assembly);
        private static readonly string covidApiUrl = resourceManager.GetString("BaseUrl", CultureInfo.CurrentCulture);

        [Microsoft.AspNetCore.Mvc.HttpGet("api/arizona")]
        public object GetArizonaData()
        {
            string arizonaUrl = covidApiUrl + resourceManager.GetString("ArizonaEndpoint");
            return GetCasesData(arizonaUrl);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("api/cases")]
        public object SearchCases([Microsoft.AspNetCore.Mvc.FromBody] SearchData searchData)
        {
            string stateUrl = covidApiUrl + searchData.State.ToLower() + resourceManager.GetString("DailyEndpoint");
            return GetCasesData(stateUrl, searchData.StartDate, searchData.EndDate);
        }

        private object GetCasesData(string url, string startDate = null, string endDate = null)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<dynamic>>(jsonData);
                int positiveCases;
                int negativeCases;
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    var startDateParsed = DateTime.ParseExact(startDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                    var endDateParsed = DateTime.ParseExact(endDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                    data = data.Where(item =>
                    {
                        string dt = Convert.ToString(item.date.Value);
                        DateTime itemDate = DateTime.ParseExact(dt, "yyyyMMdd", CultureInfo.InvariantCulture);
                        return itemDate >= startDateParsed && itemDate <= endDateParsed;
                    }).ToList();
                    positiveCases = data.Sum(item => (int?)item.positive ?? 0);
                    negativeCases = data.Sum(item => (int?)item.negative ?? 0);
                }
                else
                {
                    var last7DaysData = data.TakeLast(7);
                     positiveCases = last7DaysData.Sum(item => (int)item.positive);
                     negativeCases = last7DaysData.Sum(item => (int)item.negative);
                }
                var result = new
                {
                    positiveCases,
                    negativeCases
                };

                return result;
            }
            else
            {
                return InternalServerError();
            }
        }

        private object InternalServerError()
        {
            var errorResponse = new ErrorResponse
            {
                ErrorCode = "ERR001",
                ErrorMessage = "An error occurred while processing your request.",
                Details = "Additional details about the error can go here."
            };

            return errorResponse;
           
        }

    }
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }
    }
    public class SearchData
    {
        public string State { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
