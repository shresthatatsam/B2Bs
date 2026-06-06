using B2B.Entities.Users;

namespace B2B.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<Role> Get(Guid id);
        Task Create(Role role);
        Task Update(Role role);
        Task Delete(Guid id);
    }
}
