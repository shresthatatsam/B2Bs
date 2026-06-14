using B2B.Entities;

namespace B2B.Services.Interfaces
{
    public interface ISellerTypeService
    {
        Task<List<SellerType>> GetAll();
        Task<SellerType> Get(Guid id);
        Task Create(SellerType sellerType);
        Task Update(SellerType sellerType);
        Task Delete(Guid id);
    }
}
