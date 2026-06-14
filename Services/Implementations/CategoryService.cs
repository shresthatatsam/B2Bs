using B2B.Entities;
using B2B.Entities.Users;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class CategoryService :ICategoryService
    {
        private readonly IGenericService<Category> _service;

        public CategoryService(IGenericService<Category> service)
        {
            _service = service;
        }

        public Task<List<Category>> GetAll() => _service.GetAllAsync();
        public Task<Category> Get(Guid id) => _service.GetByIdAsync(id);
        public Task Create(Category category) => _service.CreateAsync(category);
        public Task Update(Category category) => _service.UpdateAsync(category);
        public Task Delete(Guid id) => _service.DeleteAsync(id);
    }
}
