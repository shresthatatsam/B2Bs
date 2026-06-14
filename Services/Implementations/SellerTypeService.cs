using B2B.Entities;
using B2B.Entities.Users;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class SellerTypeService :ISellerTypeService
    {
        private readonly IGenericService<SellerType> _service;

        public SellerTypeService(IGenericService<SellerType> service)
        {
            _service = service;
        }

        public Task<List<SellerType>> GetAll() => _service.GetAllAsync();
        public Task<SellerType> Get(Guid id) => _service.GetByIdAsync(id);
        public Task Create(SellerType sellerType) => _service.CreateAsync(sellerType);
        public Task Update(SellerType sellerType) => _service.UpdateAsync(sellerType);
        public Task Delete(Guid id) => _service.DeleteAsync(id);
    }
}
