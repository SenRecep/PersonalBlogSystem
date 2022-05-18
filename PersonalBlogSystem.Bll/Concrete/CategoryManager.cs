using AutoMapper;

using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Dal.Interfaces;
using PersonalBlogSystem.DTO.Category;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Bll.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task AddAsync(Category category) => _repository.AddAsync(category);

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool isLoad = false) => _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetCategoriesAsync(isLoad));
    public async Task<CategoryDto?> GetCategoryById(Guid id, bool isLoad = false) => _mapper.Map<CategoryDto>(await _repository.GetCategoryById(id, isLoad));
}
