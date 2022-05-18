using Dapper.Contrib.Extensions;

using PersonalBlogSystem.Core.Concrete;
using PersonalBlogSystem.Entities.Interfaces;

namespace PersonalBlogSystem.Entities.Concrete;

public class Blog : EntityBase, IBlog
{
    public string? Title { get; set; }
    public string? Content { get; set; }

    #region Category
    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }
    #endregion
}