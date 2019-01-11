using System.Linq;
using Template1.Common.Utils;
using Template1.Contract;
using Template1.Contract.Dtos.Microservice;
using Template1.Contract.Enum;
using Template1.Contract.Microservice.Enum;
using Template1.Repository.DemoDotNetCore;

namespace Template1.Services.Microservice.Validation
{
    public class MicroserviceValidation : IMicroserviceValidation
    {
        private readonly IMicroserviceRepository _microserviceRrpo;

        public MicroserviceValidation(IMicroserviceRepository microserviceRrpo)
        {
            _microserviceRrpo = microserviceRrpo;
        }

        public ResponseBase Check(MicroserviceDto microserviceDto)
        {
            var response = new ResponseBase { Code = (int)ResultCode.InvalidParameter };

            #region Check parameter

            if (string.IsNullOrWhiteSpace(microserviceDto.Name))
            {
                response.Msg = "Name can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ServiceCode))
            {
                response.Msg = "ServiceCode can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ServiceAliasName))
            {
                response.Msg = "ServiceAliasName can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ServiceChineseName))
            {
                response.Msg = "ServiceChineseName can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ServiceCategory))
            {
                response.Msg = "ServiceCategory can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ResponsibleTeam))
            {
                response.Msg = "ResponsibleTeam can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ProductOwner))
            {
                response.Msg = "ProductOwner can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.TechniqueOwner))
            {
                response.Msg = "TechniqueOwner can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ScrumMaster))
            {
                response.Msg = "ScrumMaster can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.Developers))
            {
                response.Msg = "Developers can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.ServiceConfluenceUrl))
            {
                response.Msg = "ServiceConfluenceUrl can not be null";
                return response;
            }
            if (string.IsNullOrWhiteSpace(microserviceDto.RepositoryName))
            {
                response.Msg = "RepositoryName can not be null";
                return response;
            }

            #endregion

            #region Check Name/ServiceCode in db

            var list = _microserviceRrpo.GetMany(
                d => (microserviceDto.Id == 0 || d.Id != microserviceDto.Id)
                && (d.Name.Equals(microserviceDto.Name) || d.ServiceCode.Equals(microserviceDto.ServiceCode)));
            if (list != null && list.Count() > 0)
            {
                var item = list.FirstOrDefault(d => d.Name.Equals(microserviceDto.Name));
                response.Code = item != null ? (int)MicroserviceResultCode.NameExisted : (int)MicroserviceResultCode.ServiceCodeExisted;
                response.Msg = EnumUtils.GetDesc((MicroserviceResultCode)response.Code);

                return response;
            }

            #endregion

            response.IsSuccess = true;
            response.Code = (int)ResultCode.Success;
            return response;
        }

    }
}
