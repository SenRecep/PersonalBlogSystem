using FluentValidation;

using PersonalBlogSystem.DTO.Content;

namespace PersonalBlogSystem.Bll.Validations.FluentValidation;

public class ContentCreateDtoValidator:AbstractValidator<ContentCreateDto>
{
    public ContentCreateDtoValidator()
    {
        When(x=>x.CategoryId is null,()=>
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        });
        
        When(x => x.CategoryId is not null, () =>
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
        });        
    }
}
