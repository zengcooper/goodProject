using System;
using System.Collections.Generic;
using System.Text;
using Template1.Contract;
using Template1.Contract.Dtos.Microservice;

namespace Template1.Services.Microservice.Validation
{
    public interface IMicroserviceValidation
    {
        ResponseBase Check(MicroserviceDto microserviceDto);
    }
}
