
using Dapper;

using PersonalBlogSystem.Dal.Concrete.DapperContrib.Contexts;
using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Contexts;
using PersonalBlogSystem.Dal.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

using System.Data;

namespace PersonalBlogSystem.Dal.Concrete.DapperContrib.Repositories;

public class DPCategoryRepository : ICategoryRepository
{
    private readonly DPDbContext _context;
    private readonly IBlogRepository _blogRepository;

    public DPCategoryRepository(DPDbContext context, IBlogRepository blogRepository)
    {
        _context = context;
        _blogRepository = blogRepository;
    }


    public async Task AddAsync(Category category)
    {
        using var con = _context.GetConnection();
        category.AssignSystemUserIdtoCreateUserId();
        await con.ExecuteAsync(
            sql: $"INSERT INTO Categories (Name, ParentId, CreatedUserId) VALUES(@Name, @ParentId, @CreatedUserId)",
            param: category);
    }

    private async Task LoadCategory(Category category, IDbConnection con)
    {
        category.Categories = await con.QueryAsync<Category>($"SELECT * FROM Categories  WHERE ParentId = @ParentId", new { ParentId = category.Id });
        category.Blogs = await _blogRepository.GetBlogsByCategoryIdAsync(category.Id);
        foreach (var sub in category.Categories)
            await LoadCategory(sub, con);
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync(bool isLoad = false)
    {
        using var con = _context.GetConnection();
        if (!isLoad)
            return await con.QueryAsync<Category>("SELECT * FROM Categories");

        var parentCategories = await con.QueryAsync<Category>("SELECT * FROM Categories WHERE ParentId IS NULL");
        foreach (var parentCategory in parentCategories)
            await LoadCategory(parentCategory, con);
        return parentCategories;
    }


    public async Task<Category?> GetCategoryById(Guid id, bool isLoad = false)
    {
        using var con = _context.GetConnection();
        var found = await con.QueryFirstOrDefaultAsync<Category>("SELECT * FROM Categories WHERE Id = @Id", new { Id = id });
        if (found is not null && isLoad)
            await LoadCategory(found,con);
        return found;
    }
}
