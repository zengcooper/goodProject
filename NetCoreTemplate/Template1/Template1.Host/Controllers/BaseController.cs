using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Template1.Host.Infrastructure;
using Template1.Common.Utils;

namespace Template1.Host.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context">ActionExecutingContext</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (context != null)
                {
                    var properties = new Dictionary<string, string>();
                    var metrics = new Dictionary<string, double>();
                    properties.Add(ApplicationLogKeyConsts.EXECUTINGTIME,
                        DateTimeOffset.Now.ToString(ApplicationLogKeyConsts.DateTimeOffsetFormat));
                    properties.Add(ApplicationLogKeyConsts.HOSTNAME, Bootstrap.DemoConfiguration.HostName);
                    properties.Add(ApplicationLogKeyConsts.HOSTADDRESSES, Bootstrap.DemoConfiguration.HostAddress);
                    properties.Add(ApplicationLogKeyConsts.APPID, Bootstrap.DemoConfiguration.AppId);
                    var actionDisplayName = string.Empty;

                    if (context.ActionDescriptor != null)
                    {
                        actionDisplayName = context.ActionDescriptor.DisplayName ?? "";
                        properties.Add(ApplicationLogKeyConsts.DISPLAYNAME, actionDisplayName);
                        metrics.Add(actionDisplayName, 1);
                    }

                    if (context.HttpContext != null)
                    {
                        var callOperationId = string.Empty;
                        if (context.HttpContext.Request != null)
                        {
                            var clientAddress = HttpUtils.RemoteIpAddress(context.HttpContext);
                            var hearders = context.HttpContext.Request.Headers;
                            var requestPath = context.HttpContext.Request.Path == null
                                ? ""
                                : context.HttpContext.Request.Path.ToString();
                            properties.Add(ApplicationLogKeyConsts.PATH, requestPath);
                            properties.Add(ApplicationLogKeyConsts.CLIENTIP, clientAddress);
                            if (hearders != null && hearders.Count > 0)
                            {
                                callOperationId = hearders[ApplicationLogKeyConsts.CALLOPERATIONID];
                                properties.Add(ApplicationLogKeyConsts.OS, hearders[ApplicationLogKeyConsts.OS]);
                                properties.Add(ApplicationLogKeyConsts.OSVERSION,
                                    hearders[ApplicationLogKeyConsts.OSVERSION]);
                                properties.Add(ApplicationLogKeyConsts.APPVERSION,
                                    hearders[ApplicationLogKeyConsts.APPVERSION]);
                            }

                            if (context.HttpContext.Request.QueryString != null)
                            {
                                context.HttpContext.Items.Add(ApplicationLogKeyConsts.QueryString,
                                    context.HttpContext.Request.QueryString.ToString());
                            }
                        }

                        callOperationId = string.IsNullOrWhiteSpace(callOperationId)
                            ? Guid.NewGuid().ToString()
                            : callOperationId;
                        properties.Add(ApplicationLogKeyConsts.CALLOPERATIONID, callOperationId);
                        context.HttpContext.Items.Add(ApplicationLogKeyConsts.CALLOPERATIONID, callOperationId);

                        //if (context.ActionArguments != null && context.ActionArguments.Count > 0)
                        //{
                        //    context.HttpContext.Items.Add(ApplicationLogKeyConsts.ACTIONPARAMETERS,
                        //        JsonConvert.SerializeObject(context.ActionArguments));
                        //}
                    }

                    Bootstrap.AppInsightsTelemetryClient.TrackEvent(actionDisplayName, properties, metrics);
                }
            }
            catch (Exception ex) { Bootstrap.AppInsightsTelemetryClient.TrackException(ex); }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context">ActionExecutedContext</param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                //TODO by sudy Response may need record
                var properties = new Dictionary<string, string>();
                var metrics = new Dictionary<string, double>();
                properties.Add(ApplicationLogKeyConsts.HOSTNAME, Bootstrap.DemoConfiguration.HostName);
                properties.Add(ApplicationLogKeyConsts.HOSTADDRESSES, Bootstrap.DemoConfiguration.HostAddress);
                properties.Add(ApplicationLogKeyConsts.APPID, Bootstrap.DemoConfiguration.AppId);
                var actionDisplayName = string.Empty;

                if (context != null && context.ActionDescriptor != null)
                {
                    actionDisplayName = context.ActionDescriptor.DisplayName ?? "";
                    properties.Add(ApplicationLogKeyConsts.DISPLAYNAME, actionDisplayName);
                }

                if (context != null && context.HttpContext != null)
                {
                    properties.Add(ApplicationLogKeyConsts.EXECUTINGTIME,
                        context.HttpContext.Items[ApplicationLogKeyConsts.EXECUTINGTIME] != null
                            ? context.HttpContext.Items[ApplicationLogKeyConsts.EXECUTINGTIME].ToString()
                            : "");
                    properties.Add(ApplicationLogKeyConsts.CALLOPERATIONID,
                        HttpUtils.GetHttpContextItem(context.HttpContext, ApplicationLogKeyConsts.CALLOPERATIONID));
                }

                if (context != null && context.Exception != null)
                {
                    metrics.Add(string.Format("{0}.Fail", actionDisplayName), 1);
                    if (context.HttpContext != null && context.HttpContext.Items[ApplicationLogKeyConsts.ACTIONPARAMETERS] != null)
                    {
                        properties.Add(ApplicationLogKeyConsts.ACTIONPARAMETERS,
                            context.HttpContext.Items[ApplicationLogKeyConsts.ACTIONPARAMETERS].ToString());
                    }
                    if (context.HttpContext != null && context.HttpContext.Items[ApplicationLogKeyConsts.QueryString] != null)
                    {
                        properties.Add(ApplicationLogKeyConsts.QueryString,
                            context.HttpContext.Items[ApplicationLogKeyConsts.QueryString].ToString());
                    }
                }
                else
                {
                    metrics.Add(string.Format("{0}.Success", actionDisplayName), 1);
                }
                properties.Add(ApplicationLogKeyConsts.EXECUTEDTIME,
                    DateTimeOffset.Now.ToString(ApplicationLogKeyConsts.DateTimeOffsetFormat));

                Bootstrap.AppInsightsTelemetryClient.TrackEvent(actionDisplayName, properties, metrics);
            }
            catch (Exception ex) { Bootstrap.AppInsightsTelemetryClient.TrackException(ex); }
            base.OnActionExecuted(context);
        }

    }
}
