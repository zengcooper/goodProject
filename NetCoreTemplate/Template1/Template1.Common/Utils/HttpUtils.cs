using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Template1.Common.Utils
{
    public class HttpUtils
    {

        /// <summary>
        /// Get RemoteIpAddress
        /// </summary>
        /// <returns>string</returns>
        public static string RemoteIpAddress(HttpContext request)
        {
            if (request == null || request.Connection == null || request.Connection.RemoteIpAddress == null)
                return string.Empty;
            return request.Connection.RemoteIpAddress.ToString();
        }

        /// <summary>
        /// Get LocalIpAddress
        /// </summary>
        /// <returns>string</returns>
        public static string LocalIpAddress(HttpContext request)
        {
            if (request == null || request.Connection == null || request.Connection.LocalIpAddress == null)
                return string.Empty;
            return request.Connection.LocalIpAddress.ToString();
        }


        /// <summary>
        /// GetCallOperationId
        /// </summary>
        /// <returns></returns>
        public static string GetHttpContextItem(HttpContext request, string itemKey)
        {
            if (request == null || request.Items == null || string.IsNullOrWhiteSpace(itemKey))
                return Guid.NewGuid().ToString();

            var callOperationId = request.Items[itemKey] ?? Guid.NewGuid();
            return callOperationId.ToString();
        }

    }
}
