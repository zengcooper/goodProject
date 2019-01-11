using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Template1.Host.Attributes
{
    /// <summary>
    /// RequireApiHttpsAttribute
    /// </summary>
    public class RequireApiHttpsAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.HttpContext.Request.IsHttps)
            {
                actionContext.Result = new ForbidResult();
            }
            base.OnActionExecuting(actionContext);
        }
    }
}
