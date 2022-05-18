using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _blogService.GetBlogsAsync();
        return Ok(data);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var data = await _blogService.GetBlogById(id);
        return data is null ? NotFound("Blog not found") : Ok(data);
    }
}
