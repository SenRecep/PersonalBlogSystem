using Microsoft.AspNetCore.Mvc;

using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _categoryService.GetCategoriesAsync();
        return Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var data = await _categoryService.GetCategoryById(id);
        return data is null ? NotFound("Category not found") : Ok(data);
    }


    [HttpGet("load")]
    public async Task<IActionResult> GetLoadedAll()
    {
        var data = await _categoryService.GetCategoriesAsync(true);
        return Ok(data);
    }

    [HttpGet("load/{id:guid}")]
    public async Task<IActionResult> GetLoadedById(Guid id)
    {
        var data = await _categoryService.GetCategoryById(id,true);
        return data is null ? NotFound("Category not found") : Ok(data);
    }
}
