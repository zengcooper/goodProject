using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template1.Common.Configuration
{
    public class DemoConfiguration : IDemoConfiguration
    {
        #region << DB Key >>

        public const string DEMODB_DOTNETCORE_CONNECTIONSTRING = "DemoDotNetCoredb";
        public const string DEMODB_DOTNETCORE_COMMAND_TIMEOUT = "DemoDotNetCoreDbCommandTimeout";
        public const string DEMODB_DOTNETFRAMEWORK_CONNECTIONSTRING = "DemoDotNetFrameworkdb";
        public const string DEMODB_DOTNETFRAMEWORK_COMMAND_TIMEOUT = "DemoDotNetFrameworkDbCommandTimeout";

        #endregion

        #region << appsettings Key >>

        public const string APPID = "AppId";
        public const string ENABLESWAGGERDOCUMENT = "EnableSwaggerDocument";

        #endregion

        private IConfiguration _configuration;
        public DemoConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string AppId
        {
            get
            {
                return _configuration.GetValue<string>(APPID);
            }
        }

        public string HostName { get { return System.Net.Dns.GetHostName(); } }

        public string HostAddress
        {
            get
            {
                var addresses = System.Net.Dns.GetHostAddresses(HostName);
                return (addresses != null && addresses.Length > 0) ? addresses[addresses.Length - 1].ToString() : "";
            }
        }

        public bool EnableSwaggerDocument
        {
            get
            {
                var enableSwaggerDocument = _configuration.GetValue<string>(ENABLESWAGGERDOCUMENT);
                return "true".Equals(enableSwaggerDocument);
            }
        }

        #region << DB >>

        public string DemoDotNetCoreDbConnectionString
        {
            get
            {
                return _configuration.GetConnectionString(DEMODB_DOTNETCORE_CONNECTIONSTRING);
            }
        }

        public int DemoDotNetCoreDbCommandTimeout
        {
            get
            {
                var timeout = _configuration.GetValue<int>(DEMODB_DOTNETCORE_COMMAND_TIMEOUT);
                return timeout > 0 ? timeout : 120;
            }
        }

        public string DemoDotNetFrameworkDbConnectionString
        {
            get
            {
                return _configuration.GetConnectionString(DEMODB_DOTNETFRAMEWORK_CONNECTIONSTRING);
            }
        }

        public int DemoDotNetFrameworkDbCommandTimeout
        {
            get
            {
                var timeout = _configuration.GetValue<int>(DEMODB_DOTNETFRAMEWORK_COMMAND_TIMEOUT);
                return timeout > 0 ? timeout : 120;
            }
        }

        #endregion
    }

}
