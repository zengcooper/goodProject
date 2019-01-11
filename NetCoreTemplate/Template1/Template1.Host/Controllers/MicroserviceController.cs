using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template1.Contract;
using Template1.Contract.Dtos.Microservice;
using Template1.Contract.Microservice;
using Template1.Services.Microservice;

namespace Template1.Host.Controllers
{
    /// <summary>
    /// Microservice V1
    /// </summary>
    [Produces("application/json")]
    [Route("v1/api/microservice")]
    [ApiController]
    public class MicroserviceController : BaseController
    {
        private readonly IMicroserviceService _microserviceService;

        /// <summary>
        /// Microservice
        /// </summary>
        /// <param name="microserviceService">IMicroserviceService</param>
        public MicroserviceController(IMicroserviceService microserviceService)
        {
            _microserviceService = microserviceService;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>BaseResponse</returns>
        [HttpGet]
        public async Task<GetMicroservicesResponse> Get()
        {
            return await _microserviceService.GetAllMicroservicesAsync();
        }

        /// <summary>
        /// Add a new Microservice
        /// </summary>
        /// <remarks>
        /// BaseResponse.Code
        /// NameExisted:30001
        /// ServiceCodeExisted:30002
        /// AddFail:30003
        /// </remarks>
        /// <param name="microserviceDto">MicroserviceDto</param>
        /// <returns>BaseResponse</returns>
        [HttpPost]
        public async Task<ResponseBase> Post([FromBody]MicroserviceDto microserviceDto)
        {
            return await _microserviceService.AddMicroservice(microserviceDto);
        }

        /// <summary>
        /// Update a new Microservice
        /// </summary>
        /// <remarks>
        /// BaseResponse.Code
        /// UpdateFail:30004
        /// </remarks>
        /// <param name="microserviceDto">MicroserviceDto</param>
        /// <returns>BaseResponse</returns>
        [HttpPut]
        public async Task<ResponseBase> Put([FromBody]MicroserviceDto microserviceDto)
        {
            return await _microserviceService.UpdateMicroservice(microserviceDto);
        }

        /// <summary>
        /// Delete a microservice by Id
        /// </summary>
        /// <remarks>
        /// BaseResponse.Code
        /// DeleteFail:30005
        /// </remarks>
        /// <param name="id">Id</param>
        /// <returns>BaseResponse</returns>
        [HttpDelete("{id}")]
        public async Task<ResponseBase> Delete(int id)
        {
            return await _microserviceService.DeleteMicroservice(id);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<GetMicroserviceDetailResponse> Get(int id)
        {
            return await _microserviceService.GetMicroserviceDetail(id);
        }


        /// <summary>
        /// query all by condition
        /// </summary>
        /// <returns>Microservices</returns>
        [HttpGet]
        [Route("getmicroservicesbypage")]
        public async Task<GetMicroservicesByPageResponse> Get([FromQuery]GetMicroservicesByPageRequest request)
        {
            return await _microserviceService.GetMicroservicesByPage(request);
        }

    }
}
