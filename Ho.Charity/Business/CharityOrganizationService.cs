using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ho.Charity.Core;
using Ho.Charity.Model;
using Ho.Charity.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ho.Charity.Business
{
    public interface ICharityOrganizationService
    {
        Task<CharityOrganizationResponse> AddCharityInformation(CharityOrganizationRequest request);

        Task<CharityOrganizationResponse> PatchCharityInformation(UpdateCharityOrganizationRequest request);

        Task<bool> DeleteCharityInformation(string id);

        Task<CharityOrganizationResponse> GetCharityInformation(Guid id);
    }


    public class CharityOrganizationService : ICharityOrganizationService
    {
        private readonly CharityOrganizationDbContext _dbContext;
        private readonly ICharityOrganizationFactory _charityOrganizationFactory;
        private readonly IMapper _mapper;


        public CharityOrganizationService(CharityOrganizationDbContext dbContext,
            ICharityOrganizationFactory charityOrganizationFactory, IMapper mapper)
        {
            _dbContext = dbContext;
            _charityOrganizationFactory = charityOrganizationFactory;
            _mapper = mapper;
        }

        public async Task<CharityOrganizationResponse> AddCharityInformation(CharityOrganizationRequest request)
        {
            CharityOrganization charityOrganization = _charityOrganizationFactory.CreateFrom(request);

            await _dbContext.AddAsync(charityOrganization);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return _mapper.Map<CharityOrganizationResponse>(charityOrganization);
            }

            return null;
        }

        public async Task<CharityOrganizationResponse> PatchCharityInformation(UpdateCharityOrganizationRequest request)
        {
            CharityOrganization charityOrganization =
                await _dbContext.CharityOrganizations.FirstOrDefaultAsync(ch => ch.Id.Equals(request.Id));

            ControlExistenceOfCharityInfomation(charityOrganization);

            _charityOrganizationFactory.ReConstituteFrom(charityOrganization, request);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CharityOrganizationResponse>(charityOrganization);
        }

        public async Task<bool> DeleteCharityInformation(string id)
        {
            CharityOrganization charityOrganization =
                await _dbContext.CharityOrganizations.FirstOrDefaultAsync(ch => ch.Id.Equals(Guid.Parse(id)));

            ControlExistenceOfCharityInfomation(charityOrganization);

            charityOrganization.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private void ControlExistenceOfCharityInfomation(CharityOrganization charityOrganization)
        {
            if (charityOrganization == null)
            {
                throw new CharityOrganizationNotFoundException("CharityOrganization not found!", 90001,
                    "CharityOrganizationNotExist");
            }
        }

        public async Task<CharityOrganizationResponse> GetCharityInformation(Guid id)
        {
            CharityOrganization charityOrganization =
                await _dbContext.CharityOrganizations.Where(ch => ch.IsActive == true)
                    .FirstOrDefaultAsync(ch => ch.Id.Equals(id));

            ControlExistenceOfCharityInfomation(charityOrganization);

            return _mapper.Map<CharityOrganizationResponse>(charityOrganization);
        }
    }
}