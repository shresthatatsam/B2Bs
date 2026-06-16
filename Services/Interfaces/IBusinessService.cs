using B2B.Entities;

namespace B2B.Services.Interfaces
{
    public interface IBusinessService
    {
        Task<Business> GetBusinessByUserIdAsync(Guid UserId);
    }
}
