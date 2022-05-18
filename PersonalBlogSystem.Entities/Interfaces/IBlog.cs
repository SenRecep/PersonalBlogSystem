using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Entities.Interfaces;

public interface IBlog : IEntityBase
{
    string? Title { get; set; }
    string? Content { get; set; }

    #region Category
    Guid CategoryId { get; set; }
    Category? Category { get; set; }
    #endregion
}
