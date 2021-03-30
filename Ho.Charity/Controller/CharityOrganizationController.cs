using System;
using System.Threading.Tasks;
using HiperServiceResultHandler;
using Ho.Charity.Business;
using Ho.Charity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ho.Charity.Controller
{
    [ApiController]
    [Route("v1/Charity")]
    public class CharityOrganizationController : ControllerBase
    {
        private readonly ICharityOrganizationService _charityOrganizationService;

        public CharityOrganizationController(ICharityOrganizationService charityOrganizationService)
        {
            _charityOrganizationService = charityOrganizationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharityOrganization([FromBody] CharityOrganizationRequest request)
        {
            var result = await _charityOrganizationService.AddCharityInformation(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var charityOrganization = await _charityOrganizationService.GetCharityInformation(id);
            return this.Result(charityOrganization);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCharityOrganization([FromBody] UpdateCharityOrganizationRequest request)
        {
            var result = await _charityOrganizationService.PatchCharityInformation(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharityOrganization(string id)
        {
            var result = await _charityOrganizationService.DeleteCharityInformation(id);
            return Ok(result);
        }
    }
}