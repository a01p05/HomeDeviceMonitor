using HomeDeviceMonitor.Application.Common.Interfaces;
using IdentityModel;
using System.Security.Claims;

namespace HomeDeviceMonitor.API.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
            Email = email ?? string.Empty;
            IsAuthenticated = !string.IsNullOrEmpty(email);
        }
    }
}
