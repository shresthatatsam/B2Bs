using B2B.Entities;
using B2B.Entities.Users;

namespace B2B.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(Guid id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Guid id);
    }
}
