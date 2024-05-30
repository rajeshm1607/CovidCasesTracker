import { Component, OnInit  } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  arizonaData: any;
  title = 'angular_api';
  state = ''; // Initialize with an empty string
  startDate = Date; // Initialize with an empty string
  endDate = Date; // Initialize with an empty string
  searchResults: any;
  dropdown = document.getElementById("stateDropdown");
  positiveCases='';
  negativeCases='';
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.fetchArizonaData();
    
  }
  handleStateFilterChange() {
    // Retrieve the selected state from the dropdown
    const selectedState = this.state;

    // Filter the records based on the selected state
    if (selectedState) {
      // Perform the filtering logic here
      // For example, you can filter the searchResults based on the selectedState
      //this.searchResults = this.searchResults.filter(result => result.state === selectedState);
    } else {
      // If no state is selected (i.e., "All States" option is selected), display all the results
      // Reset the searchResults to the original data
      this.searchResults = this.arizonaData;
    }
  }
  getArizonaData() {
   // var url = "https://localhost:7051/api/arizona";

    this.http.get<any>('/api/arizona').subscribe(
      (response) => {
        console.log('Arizona Data:', response);
        this.positiveCases = " in Arizona for last 7 days "+response.positiveCases;
       this.negativeCases=" in Arizona for last 7 days "+response.negativeCases;
      },
      (error) => {
        console.error('Error fetching Arizona data:', error);
      }
    );
  }
  
  searchCases() {
  //  var url = "https://localhost:7051/api/cases";

    const searchData = {
      state: this.state,
      startDate: this.startDate,
      endDate: this.endDate
    };
  
    this.http.post<any>('/api/cases', searchData).subscribe(
      (response) => {
        console.log('Search Results:', response);
        
        const selectedStateNme = this.usStates.find(state => state.code === this.state);

       this.positiveCases =" in the state "+ selectedStateNme?.name +" is "+response.positiveCases;
       this.negativeCases=" in the state "+ selectedStateNme?.name +" is "+response.negativeCases;

        // Process the response data
      },
      (error) => {
        console.error('Error searching cases:', error);
      }
    );
  }
  
  fetchArizonaData() {
    this.http.get<any>('/api/arizona').subscribe(data => {
      this.arizonaData = data;
    });
  }
  
   usStates = [
    { name: "Alabama", code: "AL" },
    { name: "Alaska", code: "AK" },
    { name: "Arizona", code: "AZ" },
    { name: "Arkansas", code: "AR" },
    { name: "California", code: "CA" },
    { name: "Colorado", code: "CO" },
    { name: "Connecticut", code: "CT" },
    { name: "Delaware", code: "DE" },
    { name: "Florida", code: "FL" },
    { name: "Georgia", code: "GA" },
    { name: "Hawaii", code: "HI" },
    { name: "Idaho", code: "ID" },
    { name: "Illinois", code: "IL" },
    { name: "Indiana", code: "IN" },
    { name: "Iowa", code: "IA" },
    { name: "Kansas", code: "KS" },
    { name: "Kentucky", code: "KY" },
    { name: "Louisiana", code: "LA" },
    { name: "Maine", code: "ME" },
    { name: "Maryland", code: "MD" },
    { name: "Massachusetts", code: "MA" },
    { name: "Michigan", code: "MI" },
    { name: "Minnesota", code: "MN" },
    { name: "Mississippi", code: "MS" },
    { name: "Missouri", code: "MO" },
    { name: "Montana", code: "MT" },
    { name: "Nebraska", code: "NE" },
    { name: "Nevada", code: "NV" },
    { name: "New Hampshire", code: "NH" },
    { name: "New Jersey", code: "NJ" },
    { name: "New Mexico", code: "NM" },
    { name: "New York", code: "NY" },
    { name: "North Carolina", code: "NC" },
    { name: "North Dakota", code: "ND" },
    { name: "Ohio", code: "OH" },
    { name: "Oklahoma", code: "OK" },
    { name: "Oregon", code: "OR" },
    { name: "Pennsylvania", code: "PA" },
    { name: "Rhode Island", code: "RI" },
    { name: "South Carolina", code: "SC" },
    { name: "South Dakota", code: "SD" },
    { name: "Tennessee", code: "TN" },
    { name: "Texas", code: "TX" },
    { name: "Utah", code: "UT" },
    { name: "Vermont", code: "VT" },
    { name: "Virginia", code: "VA" },
    { name: "Washington", code: "WA" },
    { name: "West Virginia", code: "WV" },
    { name: "Wisconsin", code: "WI" },
    { name: "Wyoming", code: "WY" }
  ];
 

}
