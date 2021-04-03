using System;
using System.ComponentModel.DataAnnotations;

namespace Ho.Charity.Core
{
    public class CharityOrganization
    {
        [Key] public Guid Id { get; set; } // subMerchantExternalId in Iyzico side

        [Required] public string OrganizationName { get; set; }

        [Required] public string OrganizationAuthorizedPersonEmail { get; set; }

        public string OrganizationAuthorizedPersonPhoneNumber { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string Iban { get; set; }

        [Required] public bool IsActive { get; set; }
        
        [Required] public string OrganizationAuthorizedPersonIdentityNumber { get; set; }

        public string OrganizationAuthorizedPersonName { get; set; }

        public string OrganizationAuthorizedPersonSurname { get; set; }

        public string TaxOffice { get; set; }

        public string TaxNumber { get; set; }

        public string SubMerchantKey { get; set; }

        public string MerchantId { get; set; }
    }
}