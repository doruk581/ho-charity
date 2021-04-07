using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Ho.Charity
{
    public class TelemetryInitializer : ITelemetryInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TelemetryInitializer(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor =
                httpContextAccessor ??
                throw new ArgumentNullException(nameof(httpContextAccessor));
            _webHostEnvironment = webHostEnvironment;
        }
        public void Initialize(ITelemetry telemetry)
        {
            if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
            {
                //set custom role name here
                telemetry.Context.Cloud.RoleName = "Services SRV";
                telemetry.Context.Cloud.RoleInstance = "Services SRV";
            }
            
            if (telemetry is not RequestTelemetry requestTelemetry) return;

            var claims = _httpContextAccessor.HttpContext.User.Claims;
            Claim subClaim = claims.FirstOrDefault(claim => claim.Type == "sub");
            requestTelemetry.Properties.Add("UserId", subClaim?.Value);
            // Claim stIdClaim = claims.FirstOrDefault(claim => claim.Type == "st_id"); 
            // requestTelemetry.Properties.Add("StoreId", stIdClaim?.Value);
            requestTelemetry.Properties.Add("MachineName", Environment.MachineName);
            // NOTE KVKK or GDPR NOT REMOVE!!!
            if (_webHostEnvironment.IsDevelopment() || _webHostEnvironment.IsEnvironment("Test"))
            {
                var email = claims.FirstOrDefault(claim => claim.Type == "email");
                requestTelemetry.Properties.Add("Email", email?.Value);
            }
        }
    }

    public class HealthCheckFilter : ITelemetryProcessor
    {
        private ITelemetryProcessor Next { get; set; }

        // next will point to the next TelemetryProcessor in the chain.
        public HealthCheckFilter(ITelemetryProcessor next)
        {
            this.Next = next;
        }

        public void Process(ITelemetry item)
        {
            // To filter out an item, return without calling the next processor.
            if (!OKtoSend(item))
            {
                return;
            }

            this.Next.Process(item);
        }

        // Example: replace with your own criteria.
        private bool OKtoSend(ITelemetry item)
        {
            var request = item as RequestTelemetry;
            if (request != null)
            {
                if (request.Name == "GET /health" && request.Success == true)
                {
                    return false;
                }
            }

            var dependency = item as DependencyTelemetry;
            if (dependency != null)
            {
                if (dependency.Name == "Receive" && dependency.Success == true)
                {
                    return false;
                }
            }

            return true;
        }
    }
}