#nullable disable
using Microsoft.EntityFrameworkCore;

using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Contexts;

public class EFDbContext : DbContext
{
    public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TypeBuilderExtensionMethods).Assembly);

    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
}
