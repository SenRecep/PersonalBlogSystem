using AutoMapper;

using PersonalBlogSystem.DTO.Blog;
using PersonalBlogSystem.DTO.Category;
using PersonalBlogSystem.DTO.Content;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Bll.Mapping.AutoMapper;

public class GeneralMapProfile:Profile
{
    public GeneralMapProfile()
    {
        CreateMap<ContentCreateDto, Blog>();
        CreateMap<ContentCreateDto, Category>();

        
        CreateMap<Blog, BlogDto>();
        CreateMap<Category, CategoryDto>();
    }
}
