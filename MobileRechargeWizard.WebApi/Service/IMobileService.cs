using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileRechargeWizard.WebApi.Service
{
    public interface IMobileService
    {
        Task<ApiResponseDto<IEnumerable<Mobile>>> GetAllAsync();
        Task<ApiResponseDto<Mobile>> GetByIdAsync(string id);
        Task<ApiResponseDto<Mobile>> CreateAsync(MobileRequestDto request);
        Task<ApiResponseDto<Mobile>> UpdateAsync(string id, MobileRequestDto request);
        Task<ApiResponseDto<Mobile>> DeleteAsync(string id);
    }
}
