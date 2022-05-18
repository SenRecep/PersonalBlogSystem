using PersonalBlogSystem.Core.Interfaces;

namespace PersonalBlogSystem.Bll.Interfaces;

public interface IGenericService<T> : IAsyncDisposable
        where T : class, IEntityBase, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllWithDeletedAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity, bool hardDelete = false);
}
