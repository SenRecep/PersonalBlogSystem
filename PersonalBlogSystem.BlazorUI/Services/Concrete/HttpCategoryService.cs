using PersonalBlogSystem.BlazorUI.Services.Interfaces;
using PersonalBlogSystem.DTO.Category;

using System.Net.Http.Json;

namespace PersonalBlogSystem.BlazorUI.Services.Concrete;

public class HttpCategoryService : IHttpCategoryService
{
    private readonly HttpClient _httpClient;

    public HttpCategoryService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<IEnumerable<CategoryDto>?> GetCategories()
    {
        var res = await _httpClient.GetAsync("/api/categories");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
    }

    public async Task<CategoryDto?> GetCategoryById(Guid id)
    {
        var res = await _httpClient.GetAsync($"/api/categories/{id}");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<CategoryDto>();
    }

    public async Task<IEnumerable<CategoryDto>?> GetLoadedCategories()
    {
        var res = await _httpClient.GetAsync("/api/categories/load");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
    }

    public async Task<CategoryDto?> GetLoadedCategoryById(Guid id)
    {
        var res = await _httpClient.GetAsync($"/api/categories/load/{id}");
        if (!res.IsSuccessStatusCode) return null;
        return await res.Content.ReadFromJsonAsync<CategoryDto>();
    }
}
