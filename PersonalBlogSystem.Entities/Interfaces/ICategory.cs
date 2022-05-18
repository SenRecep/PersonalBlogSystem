using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Entities.Interfaces;

public interface ICategory : IEntityBase
{
    string? Name { get; set; }

    #region Parent Category
    Guid? ParentId { get; set; }
    Category? Parent { get; set; }
    #endregion

    #region Sub Categories
    IEnumerable<Category>? Categories { get; set; }
    #endregion

    #region Blogs
    IEnumerable<Blog>? Blogs { get; set; }
    #endregion
}
