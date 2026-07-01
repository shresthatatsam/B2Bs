

using B2B.Entities.Product;
using B2B.Repositories.Interfaces;

namespace B2B.Repositories.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repo;

        public GenericService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<List<T>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repo.Update(entity);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity != null)
            {
                _repo.Delete(entity);
                await _repo.SaveAsync();
            }
        }

       
    }
}
