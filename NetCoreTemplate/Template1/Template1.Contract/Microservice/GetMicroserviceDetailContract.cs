using System;
using System.Collections.Generic;
using System.Text;
using Template1.Contract.Dtos.Microservice;

namespace Template1.Contract.Microservice
{
    /// <summary>
    /// Get Microservice Detail Request
    /// </summary>
    public class GetMicroserviceDetailRequest : RequestBase
    {
        /// <summary>
        /// Microservice Id
        /// </summary>
        public int MicroserviceId { get; set; }
    }

    /// <summary>
    /// Get Microservice Detail Response
    /// </summary>
    public class GetMicroserviceDetailResponse : ResponseBase
    {
        /// <summary>
        /// Microservice Detail
        /// </summary>
        public new MicroserviceDto Result { get; set; }
    }
}
