namespace PersonalBlogSystem.Core.StringInfos;

public class SystemUserInfo
{
    public const string SystemUserId = "5b4be8b8-a338-4446-ac09-36864dfdbe8d";
    public static Guid GetSystemUserId => Guid.Parse(SystemUserId);
}
