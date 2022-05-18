using Dapper.Contrib.Extensions;

using PersonalBlogSystem.Core.Concrete;
using PersonalBlogSystem.Entities.Interfaces;

namespace PersonalBlogSystem.Entities.Concrete;

public class Category : EntityBase, ICategory
{
    public string? Name { get; set; }

    #region Parent Category
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    #endregion

    #region Sub Categories
    public virtual IEnumerable<Category>? Categories { get; set; }
    #endregion

    #region Blogs
    public virtual IEnumerable<Blog>? Blogs { get; set; }
    #endregion
}
