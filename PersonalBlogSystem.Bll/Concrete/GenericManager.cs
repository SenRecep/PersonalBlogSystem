using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.Dal.Interfaces;

namespace PersonalBlogSystem.Bll.Concrete;

public class GenericManager<T> : IGenericService<T>
    where T : class, IEntityBase, new()
{
    private readonly IGenericRepository<T> _repository;

    public GenericManager(IGenericRepository<T> repository) => _repository = repository;
    
    public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();

    public Task<IEnumerable<T>> GetAllWithDeletedAsync() => _repository.GetAllWithDeletedAsync();

    public Task<T> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task<T> AddAsync(T entity) => _repository.AddAsync(entity);

    public Task AddRangeAsync(IEnumerable<T> entities) => _repository.AddRangeAsync(entities);

    public Task RemoveAsync(T entity, bool hardDelete = false) => _repository.RemoveAsync(entity, hardDelete);

    public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
    
    public ValueTask DisposeAsync() => _repository.DisposeAsync();
}
