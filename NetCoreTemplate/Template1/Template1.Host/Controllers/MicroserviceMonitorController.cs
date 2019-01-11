using Microsoft.AspNetCore.Mvc;

namespace Template1.Host.Controllers
{
    /// <summary>
    /// MicroserviceMonitor
    /// </summary>
    [Produces("application/json")]
    [Route("api/microservicemonitor")]
    [ApiController]
    public class MicroserviceMonitorController : BaseController
    {
        /// <summary>
        /// Check microservice is alive
        /// </summary>
        /// <returns>I am alive</returns>
        [HttpGet]
        [Route("isalive")]
        public ActionResult IsAlive()
        {
            return Json("ok");
        }
    }
}