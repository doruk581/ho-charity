using System;
using HiperRestApiPack;

namespace Ho.Charity.Model
{
    public class CharityOrganizationRequest:PagedRequest
    {
       
    }
    public class CharityOrganizationCreateRequest
    {
        public string OrganizationName { get; set; }

        public string OrganizationAuthorizedPersonEmail { get; set; }

        public string OrganizationAuthorizedPersonPhoneNumber { get; set; }

        public string Address { get; set; }

        public string Iban { get; set; }

        public string OrganizationAuthorizedPersonName { get; set; }

        public string OrganizationAuthorizedPersonSurname { get; set; }

        public string TaxOffice { get; set; }

        public string TaxNumber { get; set; }
        
        public string OrganizationAuthorizedPersonIdentityNumber { get; set; }
    }

    public class CharityOrganizationResponse
    {
        public Guid Id { get; set; }

        public string OrganizationName { get; set; }

        public string SubMerchantKey { get; set; }

        public string MerchantId { get; set; }

        public string TaxOffice { get; set; }

        public string TaxNumber { get; set; }

        public string Address { get; set; }

        public string Iban { get; set; }

        public string OrganizationAuthorizedPersonEmail { get; set; }
        
        public string OrganizationAuthorizedPersonIdentityNumber { get; set; }
    }

    public class UpdateCharityOrganizationRequest
    {
        public Guid Id { get; set; }

        public string SubMerchantKey { get; set; }

        public string MerchantId { get; set; }
    }
}