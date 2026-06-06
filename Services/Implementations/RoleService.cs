using B2B.Entities.Users;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IGenericService<Role> _service;

        public RoleService(IGenericService<Role> service)
        {
            _service = service;
        }

        public Task<List<Role>> GetAll() => _service.GetAllAsync();
        public Task<Role> Get(Guid id) => _service.GetByIdAsync(id);
        public Task Create(Role role) => _service.CreateAsync(role);
        public Task Update(Role role) => _service.UpdateAsync(role);
        public Task Delete(Guid id) => _service.DeleteAsync(id);
    }
}
