using PersonalBlogSystem.Core.Interfaces;

namespace PersonalBlogSystem.DTO.Content;

public class ContentCreateDto:IDTO
{
    public string? Name { get; set; }

    public Guid? ParentId { get; set; }


    public string? Title { get; set; }
    public string? Content { get; set; }

    public Guid? CategoryId { get; set; }


    public bool IsCategory => CategoryId is  null;

}
