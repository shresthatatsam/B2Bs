using System.Linq.Expressions;

namespace B2B.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
