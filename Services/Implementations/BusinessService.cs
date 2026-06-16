using B2B.Data;
using B2B.Entities;
using B2B.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace B2B.Services.Implementations
{
    public class BusinessService :IBusinessService
    {
        private readonly AppDbContext _dbSet;
        public BusinessService(AppDbContext dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task<Business> GetBusinessByUserIdAsync(Guid UserId)
        {
            var data = await _dbSet.Businesses.Where(x => x.UserId == UserId).Include(x => x.User).FirstOrDefaultAsync(); /*FirstOrDefaultAsync(x=>x.UserId == UserId) ?? null;*/
            return new Business
            {
                BusinessName = data?.BusinessName ?? string.Empty,
                Description = data?.Description ?? string.Empty,
                SellerTypeId = data?.SellerTypeId ?? Guid.Empty,
                UserId = UserId,
                Id = data.Id
            };
        }
    }
}
