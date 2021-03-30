using System;
using HiperServiceResultHandler;

namespace Ho.Charity.Core
{
    public class CharityOrganizationNotFoundException : ServiceException
    {
        public CharityOrganizationNotFoundException(string userMessage, int errorCode, string userMessageCode = null) :
            base(userMessage, errorCode, userMessageCode)
        {
        }

        public CharityOrganizationNotFoundException(string userMessage, int errorCode, string userMessageCode = null,
            string message = null, Exception innerException = null) : base(userMessage, errorCode, userMessageCode,
            message, innerException)
        {
        }
    }
}