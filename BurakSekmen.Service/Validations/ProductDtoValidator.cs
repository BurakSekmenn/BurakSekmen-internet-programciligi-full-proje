using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.DTOs;
using FluentValidation;

namespace BurakSekmen.Service.Validations
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün Açıklması boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Ürün stok adedi boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Ürün resmi boş geçilemez");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş geçilemez");
        }
    }
}
