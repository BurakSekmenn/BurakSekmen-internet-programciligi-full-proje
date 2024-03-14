using BurakSekmen.Core.DTOs;
using FluentValidation;

namespace BurakSekmen.Service.Validations
{
    public class CategoryDtoValidator:AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        }
    }
}
