using Dapper;

using PersonalBlogSystem.Dal.Concrete.DapperContrib.Contexts;
using PersonalBlogSystem.Dal.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Concrete.DapperContrib.Repositories;

public class DPBlogRepository : IBlogRepository
{
    private readonly DPDbContext _context;

    public DPBlogRepository(DPDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Blog blog)
    {
        using var con = _context.GetConnection();
        blog.AssignSystemUserIdtoCreateUserId();
        await con.ExecuteAsync(
            sql: $"INSERT INTO Blogs (Title, Content, CategoryId,CreatedUserId) VALUES(@Title, @Content, @CategoryId, @CreatedUserId)",
            param: blog);
    }

    public async Task<Blog?> GetBlogById(Guid id)
    {
        using var con = _context.GetConnection();
        var query = "SELECT * FROM Blogs b INNER JOIN Categories c ON b.CategoryId = c.Id WHERE b.Id = @Id";
        var data = await con.QueryAsync<Blog, Category, Blog>(query,
            (blog, category) =>
            {
                blog.Category = category;
                return blog;
            },
            new { Id = id });
        return data.FirstOrDefault();   
    }

    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        using var con = _context.GetConnection();
        var query = "SELECT * FROM Blogs b INNER JOIN Categories c ON b.CategoryId = c.Id";
        var data = await con.QueryAsync<Blog, Category, Blog>(query,
            (blog, category) =>
            {
                blog.Category = category;
                return blog;
            });
        return data;
    }

    public async Task<IEnumerable<Blog>> GetBlogsByCategoryIdAsync(Guid id)
    {
        using var con = _context.GetConnection();
        var data= await con.QueryAsync<Blog>($"SELECT * FROM Blogs  WHERE CategoryId = @CategoryId", new { CategoryId = id });
        return data;
    }
}
