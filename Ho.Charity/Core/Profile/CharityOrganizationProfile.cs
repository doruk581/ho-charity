using Ho.Charity.Model;

namespace Ho.Charity.Core.Profile
{
    public class CharityOrganizationProfile : AutoMapper.Profile
    {
        public CharityOrganizationProfile()
        {
            CreateMap<CharityOrganization, CharityOrganizationResponse>();
        }
    }
}