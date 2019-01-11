using System.Collections.Generic;
using Template1.Contract.Dtos.Microservice;

namespace Template1.Contract.Microservice
{
    /// <summary>
    /// GetListByPageRequest
    /// </summary>
    public class GetMicroservicesByPageRequest : PageRequestBase
    {
        /// <summary>
        /// Microservice Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Microservice Code
        /// </summary>
        public string ServiceCode { get; set; }
    }

    /// <summary>
    /// GetListByPageResponse
    /// </summary>
    public class GetMicroservicesByPageResponse : PageResponseBase
    {
        /// <summary>
        /// IList.MicroserviceDto
        /// </summary>
        public new IList<MicroserviceDto> Result { get; set; }
    }
}