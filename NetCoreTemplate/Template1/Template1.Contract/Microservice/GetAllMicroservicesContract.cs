using System.Collections.Generic;
using Template1.Contract.Dtos.Microservice;

namespace Template1.Contract.Microservice
{
    /// <summary>
    /// GetMicroservicesRequest
    /// </summary>
    public class GetMicroservicesRequest : RequestBase
    {

    }

    /// <summary>
    /// GetMicroservicesResponse
    /// </summary>
    public class GetMicroservicesResponse : ResponseBase
    {
        /// <summary>
        /// IList.MicroserviceDto
        /// </summary>
        public new IList<MicroserviceDto> Result { get; set; }
    }
}
