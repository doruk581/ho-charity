using System;
using System.Threading.Tasks;
using HiperRestApiPack;
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
        private readonly IFilteredQuery _filteredQuery;

        public CharityOrganizationController(ICharityOrganizationService charityOrganizationService,
            IFilteredQuery filteredQuery)
        {
            _charityOrganizationService = charityOrganizationService;
            _filteredQuery = filteredQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CharityOrganizationRequest request)
        {
            var query = _charityOrganizationService.Get(request);
            var result = await _filteredQuery.ToPageList(query, request);
            return this.Result(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharityOrganization([FromBody] CharityOrganizationCreateRequest request)
        {
            var result = await _charityOrganizationService.AddCharityInformation(request);
            return this.Result(result);
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
            return this.Result(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharityOrganization(string id)
        {
            var result = await _charityOrganizationService.DeleteCharityInformation(id);
            return Ok(result);
        }
    }
}