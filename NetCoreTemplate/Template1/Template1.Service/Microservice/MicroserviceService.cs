using System.Threading.Tasks;
using BMW.Omc.ConfigService.Client;
using BMW.Omc.ConfigService.Client.Instrument.Wrappers;
using System.Collections.Generic;
using Template1.Contract;
using Template1.Contract.Dtos.Microservice;
using Template1.Contract.Enum;
using Template1.Contract.Microservice;
using Template1.Contract.Microservice.Enum;
using Template1.Entity.DemoDotNetCore;
using Template1.Repository.DemoDotNetCore;
using Template1.Services.Microservice.Validation;
using System.Linq;

namespace Template1.Services.Microservice
{
    public class MicroserviceService : IMicroserviceService
    {
        private const string ModuleName = "MicroserviceService";

        private readonly IAppInsightsTelemetryClient _insightsTelemetryClient;
        private readonly OmcRunner _runner;
        private readonly IMicroserviceRepository _microserviceRrpo;
        private readonly IMicroserviceValidation _microserviceValidation;

        public MicroserviceService(
            IAppInsightsTelemetryClient insightsTelemetryClient,
            OmcRunner runner,
            IMicroserviceRepository microserviceRrpo,
            IMicroserviceValidation microserviceValidation)
        {
            _runner = runner;
            _insightsTelemetryClient = insightsTelemetryClient;
            _microserviceRrpo = microserviceRrpo;
            _microserviceValidation = microserviceValidation;
        }

        private MicroserviceEntity ConvertDtoToEntity(MicroserviceDto microserviceDto)
        {
            if (microserviceDto == null)
                return null;

            var entity = new MicroserviceEntity
            {
                Id = microserviceDto.Id,
                Name = microserviceDto.Name,
                Description = microserviceDto.Description,
                ServiceCode = microserviceDto.ServiceCode,
                SortNo = microserviceDto.SortNo,
                ServiceAliasName = microserviceDto.ServiceAliasName,
                ServiceChineseName = microserviceDto.ServiceChineseName,
                ServiceCategory = microserviceDto.ServiceCategory,
                Dependencies = microserviceDto.Dependencies,
                CodingLanguage = microserviceDto.CodingLanguage,
                ResponsibleTeam = microserviceDto.ResponsibleTeam,
                ProductOwner = microserviceDto.ProductOwner,
                TechniqueOwner = microserviceDto.TechniqueOwner,
                ScrumMaster = microserviceDto.ScrumMaster,
                Developers = microserviceDto.Developers,
                ServiceConfluenceUrl = microserviceDto.ServiceConfluenceUrl,
                RepositoryName = microserviceDto.RepositoryName,
                AzureResourceType = microserviceDto.AzureResourceType
            };

            return entity;
        }
        private MicroserviceDto ConvertEntityToDto(MicroserviceEntity entity)
        {
            if (entity == null)
                return null;

            var dto = new MicroserviceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ServiceCode = entity.ServiceCode,
                SortNo = entity.SortNo,
                ServiceAliasName = entity.ServiceAliasName,
                ServiceChineseName = entity.ServiceChineseName,
                ServiceCategory = entity.ServiceCategory,
                Dependencies = entity.Dependencies,
                CodingLanguage = entity.CodingLanguage,
                ResponsibleTeam = entity.ResponsibleTeam,
                ProductOwner = entity.ProductOwner,
                TechniqueOwner = entity.TechniqueOwner,
                ScrumMaster = entity.ScrumMaster,
                Developers = entity.Developers,
                ServiceConfluenceUrl = entity.ServiceConfluenceUrl,
                RepositoryName = entity.RepositoryName,
                AzureResourceType = entity.AzureResourceType
            };

            return dto;
        }

        /// <summary>
        /// Add microservice
        /// </summary>
        /// <param name="microserviceDto">MicroserviceDto</param>
        /// <returns>BaseResponse</returns>
        public async Task<ResponseBase> AddMicroservice(MicroserviceDto microserviceDto)
        {
            var response = _microserviceValidation.Check(microserviceDto);
            if (!response.IsSuccess)
                return response;

            var entity = ConvertDtoToEntity(microserviceDto);
            var result = await _runner.RunAsync(ModuleName, _microserviceRrpo.AddAsync, entity);
            if (result.AnyErrors || result.ResultObject < 1)
            {
                response.Code = (int)MicroserviceResultCode.AddFail;
                response.Msg = result.Message;
                _insightsTelemetryClient.TrackException(result.ErrorContent);
                return response;
            }

            response.Code = (int)ResultCode.Success;

            return response;
        }

        /// <summary>
        /// Update Microservice
        /// </summary>
        /// <param name="microserviceDto">MicroserviceDto</param>
        /// <returns></returns>
        public async Task<ResponseBase> UpdateMicroservice(MicroserviceDto microserviceDto)
        {
            var response = _microserviceValidation.Check(microserviceDto);
            if (!response.IsSuccess)
                return response;

            var entity = ConvertDtoToEntity(microserviceDto);
            var result = await _microserviceRrpo.UpdateAsync(entity);
            response.Code = result > 0 ? (int)ResultCode.Success : (int)MicroserviceResultCode.UpdateFail;

            return response;
        }

        /// <summary>
        /// Delete Microservice by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseBase> DeleteMicroservice(int id)
        {
            var result = await _microserviceRrpo.DeleteAsync(new MicroserviceEntity { Id = id });

            return new ResponseBase { IsSuccess = true, Code = result > 0 ? (int)ResultCode.Success : (int)MicroserviceResultCode.DeleteFail };
        }

        /// <summary>
        /// Get All Microservices
        /// </summary>
        /// <returns></returns>
        public async Task<GetMicroservicesResponse> GetAllMicroservicesAsync()
        {
            var list = await _microserviceRrpo.GetAllAsync();
            var result = new List<MicroserviceDto>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    result.Add(ConvertEntityToDto(item));
            }
            return new GetMicroservicesResponse { IsSuccess = true, Code = (int)ResultCode.Success, Result = result };
        }

        /// <summary>
        /// Get Microservices by page
        /// </summary>
        /// <param name="request">GetListByPageRequest</param>
        /// <returns></returns>
        public async Task<GetMicroservicesByPageResponse> GetMicroservicesByPage(GetMicroservicesByPageRequest request)
        {
            var entity = new MicroserviceEntity { Name = request.Name, ServiceCode = request.ServiceCode };
            var pageData = await _microserviceRrpo.GetListByPageAsync(entity, request.PageIndex, request.PageSize);
            var list = new List<MicroserviceDto>();
            foreach (var item in pageData.Item2)
            {
                list.Add(ConvertEntityToDto(item));
            }
            return new GetMicroservicesByPageResponse { IsSuccess = true, Code = (int)ResultCode.Success, TotalCount = pageData.Item1, Result = list };
        }

        /// <summary>
        /// Get Microservice Detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetMicroserviceDetailResponse> GetMicroserviceDetail(int id)
        {
            var entity = await _microserviceRrpo.GetByIdAsync(id);
            return new GetMicroserviceDetailResponse { IsSuccess = true, Code = (int)ResultCode.Success, Result = ConvertEntityToDto(entity) };
        }
    }
}
