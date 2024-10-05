using Microsoft.AspNetCore.Mvc;
using MobileRechargeWizard.WebApi.Dto;
using MobileRechargeWizard.WebApi.Service;
using MobileRechargeWizard.WebApi.Utilities.Enums;

namespace MobileRechargeWizard.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RechargePlanController : ControllerBase
    {
        private readonly IRechargePlanService rechargePlanService;

        public RechargePlanController(IRechargePlanService rechargePlanService)
        {
            this.rechargePlanService = rechargePlanService;
        }

        [HttpPost("AddRechargePlan")]
        public async Task<IActionResult> AddRechargePlan(RechargePlanRequestDto request)
        {
            var result = await rechargePlanService.CreateRechargePlan(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllRechargePlan")]
        public async Task<IActionResult> GetAllRechargePlan()
        {
            var result = await rechargePlanService.GetAllRechargePlan();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetRechargePlanById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await rechargePlanService.GetRechargePlanById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateRechargePlanById")]
        public async Task<IActionResult> UpdateRechargePlanById(string id, [FromBody] RechargePlanRequestDto request)
        {
            var result = await rechargePlanService.UpdateRechargePlanById(id, request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteRechargePlanById")]
        public async Task<IActionResult> DeleteRechargePlanById(string id)
        {
            var result = await rechargePlanService.DeleteRechargePlanById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
