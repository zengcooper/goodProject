using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Template1.Host.Infrastructure;
using Template1.Common.Utils;

namespace Template1.Host.Attributes
{
    /// <summary>
    /// AiHandleErrorAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AiHandleExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            LogException(filterContext);
            base.OnException(filterContext);
        }

        private void LogException(ExceptionContext context)
        {
            try
            {
                var callOperationId = string.Empty;
                var properties = new Dictionary<string, string>();
                var metrics = new Dictionary<string, double>();
                var clientAddress = HttpUtils.RemoteIpAddress(context.HttpContext);
                properties.Add(ApplicationLogKeyConsts.EXECUTINGTIME,
                    DateTimeOffset.Now.ToString(ApplicationLogKeyConsts.DateTimeOffsetFormat));
                properties.Add(ApplicationLogKeyConsts.HOSTNAME, Bootstrap.DemoConfiguration.HostName);
                properties.Add(ApplicationLogKeyConsts.HOSTADDRESSES, Bootstrap.DemoConfiguration.HostAddress);
                properties.Add(ApplicationLogKeyConsts.APPID, Bootstrap.DemoConfiguration.AppId);
                properties.Add(ApplicationLogKeyConsts.CLIENTIP, clientAddress);

                if (context.ActionDescriptor != null)
                {
                    properties.Add(ApplicationLogKeyConsts.DISPLAYNAME, context.ActionDescriptor.DisplayName);
                    metrics.Add(context.ActionDescriptor.DisplayName, 1);
                }

                if (context.HttpContext != null && context.HttpContext.Request != null)
                {
                    var hearders = context.HttpContext.Request.Headers;
                    var requestPath = context.HttpContext.Request.Path == null
                        ? ""
                        : context.HttpContext.Request.Path.ToString();
                    properties.Add(ApplicationLogKeyConsts.PATH, requestPath);
                    if (hearders != null && hearders.Count > 0)
                    {
                        callOperationId = hearders[ApplicationLogKeyConsts.CALLOPERATIONID];
                        properties.Add(ApplicationLogKeyConsts.OS, hearders[ApplicationLogKeyConsts.OS]);
                        properties.Add(ApplicationLogKeyConsts.OSVERSION,
                            hearders[ApplicationLogKeyConsts.OSVERSION]);
                        properties.Add(ApplicationLogKeyConsts.APPVERSION,
                            hearders[ApplicationLogKeyConsts.APPVERSION]);
                    }
                }

                callOperationId = string.IsNullOrWhiteSpace(callOperationId)
                    ? HttpUtils.GetHttpContextItem(context.HttpContext, ApplicationLogKeyConsts.CALLOPERATIONID)
                    : callOperationId;
                properties.Add(ApplicationLogKeyConsts.CALLOPERATIONID, callOperationId);

                Bootstrap.AppInsightsTelemetryClient.TrackException(context.Exception, properties, metrics);
            }
            catch (Exception ex)
            {
                Bootstrap.AppInsightsTelemetryClient.TrackException(ex);
            }
        }
    }
}
