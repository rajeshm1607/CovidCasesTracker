﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Covid_Web_API {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Covid_Web_API.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyyMMdd.
        /// </summary>
        public static string ApiDateFormat {
            get {
                return ResourceManager.GetString("ApiDateFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to az/daily.json.
        /// </summary>
        public static string ArizonaEndpoint {
            get {
                return ResourceManager.GetString("ArizonaEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://api.covidtracking.com/v1/states/.
        /// </summary>
        public static string BaseUrl {
            get {
                return ResourceManager.GetString("BaseUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /daily.json.
        /// </summary>
        public static string DailyEndpoint {
            get {
                return ResourceManager.GetString("DailyEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy-MM-dd&apos;T&apos;HH:mm:ss.fff&apos;Z&apos;.
        /// </summary>
        public static string DateFormat {
            get {
                return ResourceManager.GetString("DateFormat", resourceCulture);
            }
        }
    }
}