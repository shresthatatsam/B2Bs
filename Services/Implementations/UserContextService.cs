using B2B.Entities;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;
using System.Security.Claims;

namespace B2B.Services.Implementations
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBusinessService _BusinessService;

        public UserContextService(IHttpContextAccessor httpContextAccessor, IBusinessService businessService)
        {
            _httpContextAccessor = httpContextAccessor;
            _BusinessService = businessService;
        }

        private ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated()
        {
            return User?.Identity?.IsAuthenticated ?? false;
        }

        public Guid GetUserId()
        {
            var value = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Guid.TryParse(value, out var id)
                ? id
                : Guid.Empty;
        }

        public string GetEmail()
        {
            return User?.FindFirst(ClaimTypes.Email)?.Value;
        }

        public string GetRole()
        {
            return User?.FindFirst(ClaimTypes.Role)?.Value;
        }

        

    }
}
