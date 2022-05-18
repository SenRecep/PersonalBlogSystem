using PersonalBlogSystem.BlazorUI.Services.Interfaces;
using PersonalBlogSystem.DTO.Blog;

using System.Net.Http.Json;

namespace PersonalBlogSystem.BlazorUI.Services.Concrete;

public class HttpBlogService : IHttpBlogService
{
    private readonly HttpClient _httpClient;

    public HttpBlogService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<BlogDto?> GetBlogByIdAsync(Guid id)
    {
        var res = await _httpClient.GetAsync($"/api/blogs/{id}");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<BlogDto>();
    }
    public async Task<IEnumerable<BlogDto>?> GetBlogsAsync()
    {
        var res = await _httpClient.GetAsync("/api/blogs");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<IEnumerable<BlogDto>>();
    }
}