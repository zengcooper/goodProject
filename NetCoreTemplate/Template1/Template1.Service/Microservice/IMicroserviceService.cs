using System.Threading.Tasks;
using Template1.Contract;
using Template1.Contract.Dtos.Microservice;
using Template1.Contract.Microservice;

namespace Template1.Services.Microservice
{
    public interface IMicroserviceService
    {
        Task<ResponseBase> AddMicroservice(MicroserviceDto microserviceDto);

        Task<ResponseBase> UpdateMicroservice(MicroserviceDto microserviceDto);

        Task<ResponseBase> DeleteMicroservice(int id);

        Task<GetMicroservicesResponse> GetAllMicroservicesAsync();

        Task<GetMicroservicesByPageResponse> GetMicroservicesByPage(GetMicroservicesByPageRequest request);

        Task<GetMicroserviceDetailResponse> GetMicroserviceDetail(int id);
    }
}