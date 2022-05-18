using PersonalBlogSystem.DTO.Content;

namespace PersonalBlogSystem.BlazorUI.Services.Interfaces;

public interface IHttpContentService
{
    Task<bool> CreateContent(ContentCreateDto dto);
}
