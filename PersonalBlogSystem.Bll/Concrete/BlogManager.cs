using AutoMapper;

using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Dal.Interfaces;
using PersonalBlogSystem.DTO.Blog;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Bll.Concrete;

public class BlogManager : IBlogService
{
    private readonly IBlogRepository _repository;
    private readonly IMapper _mapper;

    public BlogManager(IBlogRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task AddAsync(Blog blog) => _repository.AddAsync(blog);

    public async Task<BlogDto?> GetBlogById(Guid id) =>
        _mapper.Map<BlogDto?>(await _repository.GetBlogById(id));

    public async Task<IEnumerable<BlogDto>> GetBlogsAsync() =>
        _mapper.Map<IEnumerable<BlogDto>>(await _repository.GetBlogsAsync());
}
