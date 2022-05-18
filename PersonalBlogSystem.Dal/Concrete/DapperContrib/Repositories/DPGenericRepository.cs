using Dapper;
using Dapper.Contrib.Extensions;

using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.Dal.Concrete.DapperContrib.Contexts;
using PersonalBlogSystem.Dal.Interfaces;

using System.Data;

namespace PersonalBlogSystem.Dal.Concrete.DapperContrib.Repositories;

public class DPGenericRepository<T> : IGenericRepository<T>
    where T : class, IEntityBase, new()
{
    private readonly IDbConnection _dbConnection;

    public DPGenericRepository(DPDbContext context)
    {
        _dbConnection = context.GetConnection();
    }
    #region GetAll
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var records = await _dbConnection.GetAllAsync<T>();
        return records.Where(x => x.IsDeleted == false);
    }

    public Task<IEnumerable<T>> GetAllWithDeletedAsync() => _dbConnection.GetAllAsync<T>();
    #endregion

    #region Get
    public Task<T> GetByIdAsync(Guid id) => _dbConnection.GetAsync<T>(id);
    #endregion

    #region CRUD

    public async Task<T> AddAsync(T entity)
    {
        entity.AssignSystemUserIdtoCreateUserId();
        entity.CreatedTime = DateTime.Now;
        await _dbConnection.InsertAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        foreach (var item in entities)
        {
            item.AssignSystemUserIdtoCreateUserId();
            item.CreatedTime = DateTime.Now;

        }
        await _dbConnection.InsertAsync(entities);
    }

    public async Task UpdateAsync(T entity)
    {
        entity.AssignSystemUserIdtoUpdatedUserId();
        entity.UpdatedTime = DateTime.Now;
        await _dbConnection.UpdateAsync(entity);
    }

    public async Task RemoveAsync(T entity, bool hardDelete = false)
    {
        if (hardDelete)
        {
            await _dbConnection.DeleteAsync(entity);
            return;
        }

        entity.IsDeleted = true;
        await UpdateAsync(entity);
    }

    #endregion

    #region Dispose

    public ValueTask DisposeAsync()
    {
        _dbConnection.Dispose();
        return ValueTask.CompletedTask;
    }
    #endregion
}
