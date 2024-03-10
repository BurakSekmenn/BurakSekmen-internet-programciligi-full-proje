using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.DTOs;
using FluentValidation;

namespace BurakSekmen.Service.Validations
{
    public class ProductFeatureDtoValidator:AbstractValidator<ProductFeatureDto>
    {
        public ProductFeatureDtoValidator()
        {
            RuleFor(x => x.Color).NotEmpty().WithMessage("Renk boş geçilemez");
            RuleFor(x => x.Height).NotEmpty().WithMessage("Yükseklik boş geçilemez");
            RuleFor(x => x.Width).NotEmpty().WithMessage("Genişlik boş geçilemez");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id boş geçilemez");
        }
    }
}
