using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Dal.Interfaces;
using PersonalBlogSystem.DTO.Content;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public ContentsController(IMapper mapper,IBlogService blogService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _blogService = blogService;
            _categoryService = categoryService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ContentCreateDto createDto)
        {
            if (createDto.IsCategory)
            {
                var category = _mapper.Map<Category>(createDto);
                await _categoryService.AddAsync(category);
                return Ok();
            }

            var blog = _mapper.Map<Blog>(createDto);
            await _blogService.AddAsync(blog);
            return Ok();
        }
    }
}
