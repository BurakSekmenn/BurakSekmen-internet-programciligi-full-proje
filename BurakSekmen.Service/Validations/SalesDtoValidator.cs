using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.DTOs;
using FluentValidation;

namespace BurakSekmen.Service.Validations
{
    public class SalesDtoValidator:AbstractValidator<SalesDto>
    {
        public SalesDtoValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Miktar boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez");
            //RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Toplam fiyat boş geçilemez");
            //RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id boş geçilemez");
            //RuleFor(x => x.PersonId).NotEmpty().WithMessage("Kişi Id boş geçilemez");
        }
    }
}
