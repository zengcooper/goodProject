using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Template1.Host.Attributes
{
    /// <summary>
    /// AuthTokenParameter
    /// </summary>
    public class AuthTokenParameter : IOperationFilter
    {

        /// <summary>        
        /// OperationFilter Apply
        /// </summary>        
        /// <param name="operation"></param>        
        /// <param name="context"></param>        
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<IParameter>();
            //var attrs = context.ApiDescription.ActionDescriptor.AttributeRouteInfo;
            if (!(context.ApiDescription.ActionDescriptor is ControllerActionDescriptor descriptor)) return;
            var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(true);
            var isAnonymous = actionAttributes.Any(a => a is AllowAnonymousAttribute);
            if (!isAnonymous)
            {
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "AccessToken",
                    In = "header", //query header body path formData                        
                    Type = "string",
                    Required = false,
                    Description = "AccessToken got from service owner"
                });
            }
        }

    }
}
