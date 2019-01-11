using System;
using System.Collections.Generic;
using System.Text;

namespace Template1.Common.Configuration
{
    public interface IDemoConfiguration
    {
        #region << DB >>

        string DemoDotNetCoreDbConnectionString { get; }

        int DemoDotNetCoreDbCommandTimeout { get; }

        string DemoDotNetFrameworkDbConnectionString { get; }

        int DemoDotNetFrameworkDbCommandTimeout { get; }

        #endregion

        #region << AppSetting >>

        bool EnableSwaggerDocument { get; }

        string AppId { get; }

        string HostName { get; }

        string HostAddress { get; }

        #endregion

    }
}
