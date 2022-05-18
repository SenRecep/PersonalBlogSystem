using PersonalBlogSystem.BlazorUI.Services.Interfaces;
using PersonalBlogSystem.DTO.Content;

using System.Net.Http.Json;

namespace PersonalBlogSystem.BlazorUI.Services.Concrete;

public class HttpContentService : IHttpContentService
{
    private readonly HttpClient _httpClient;

    public HttpContentService(HttpClient httpClient) => _httpClient = httpClient;
    public async Task<bool> CreateContent(ContentCreateDto dto)
    {
        var res = await _httpClient.PostAsJsonAsync("/api/contents", dto);
        return res.IsSuccessStatusCode;
    }
}
