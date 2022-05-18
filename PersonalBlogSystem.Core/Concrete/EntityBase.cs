using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.Core.StringInfos;

namespace PersonalBlogSystem.Core.Concrete;

public abstract class EntityBase : IEntityBase
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public Guid CreatedUserId { get; set; }
    public Guid? UpdatedUserId { get; set; }
    public bool IsDeleted { get; set; }

    public void AssignSystemUserIdtoCreateUserId()
    {
        if (CreatedUserId == Guid.Empty)
            CreatedUserId =SystemUserInfo.GetSystemUserId;
    }

    public void AssignSystemUserIdtoUpdatedUserId()
    {
        if (UpdatedUserId == Guid.Empty)
            UpdatedUserId = SystemUserInfo.GetSystemUserId;
    }
}
