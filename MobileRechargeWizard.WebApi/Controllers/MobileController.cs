using Microsoft.AspNetCore.Mvc;
using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Service;
using System.Threading.Tasks;

namespace MobileRechargeWizard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService mobileService;

        public MobileController(IMobileService mobileService)
        {
            this.mobileService = mobileService;
        }

        [HttpPost("AddMobileData")]
        public async Task<IActionResult> AddMobileData([FromBody] MobileRequestDto request)
        {
            var result = await mobileService.CreateAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllMobileData")]
        public async Task<IActionResult> GetAllMobileData()
        {
            var response = await mobileService.GetAllAsync();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetMobileDataById")]
        public async Task<IActionResult> GetMobileDataById(string id)
        {
            var response = await mobileService.GetByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateMobileDataById")]
        public async Task<IActionResult> UpdateMobileDataById(string id, [FromBody] MobileRequestDto request)
        {
            var response = await mobileService.UpdateAsync(id, request);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteMobileDataById")]
        public async Task<IActionResult> DeleteMobileDataById(string id)
        {
            var response = await mobileService.DeleteAsync(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
