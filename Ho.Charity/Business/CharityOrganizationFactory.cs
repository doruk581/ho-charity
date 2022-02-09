using Ho.Charity.Core;
using Ho.Charity.Model;

namespace Ho.Charity.Business
{
    public interface ICharityOrganizationFactory
    {
        CharityOrganization CreateFrom(CharityOrganizationCreateRequest request);

        void ReConstituteFrom(CharityOrganization charityOrganization, UpdateCharityOrganizationRequest request);
    }

    public class CharityOrganizationFactory : ICharityOrganizationFactory
    {
        public CharityOrganization CreateFrom(CharityOrganizationCreateRequest request)
        {
            return new CharityOrganization
            {
                Address = request.Address,
                Iban = request.Iban,
                OrganizationName = request.OrganizationName,
                TaxNumber = request.TaxNumber,
                TaxOffice = request.TaxOffice,
                OrganizationAuthorizedPersonEmail = request.OrganizationAuthorizedPersonEmail,
                OrganizationAuthorizedPersonName = request.OrganizationAuthorizedPersonName,
                OrganizationAuthorizedPersonSurname = request.OrganizationAuthorizedPersonSurname,
                OrganizationAuthorizedPersonPhoneNumber = request.OrganizationAuthorizedPersonPhoneNumber,
                OrganizationAuthorizedPersonIdentityNumber = request.OrganizationAuthorizedPersonIdentityNumber,
                IsActive = false
            };
        }

        public void ReConstituteFrom(CharityOrganization charityOrganization, UpdateCharityOrganizationRequest request)
        {
            charityOrganization.MerchantId = request.MerchantId;
            charityOrganization.IsActive = true;
        }
    }
}