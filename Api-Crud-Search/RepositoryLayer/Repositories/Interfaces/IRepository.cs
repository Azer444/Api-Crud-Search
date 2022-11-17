using DomainLayer.Common;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Interfaces
{
    
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
    }
}
