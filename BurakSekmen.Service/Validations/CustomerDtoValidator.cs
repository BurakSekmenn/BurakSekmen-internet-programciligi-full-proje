using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakSekmen.Service.Validations
{
    public class CustomerDtoValidator:IEntityTypeConfiguration<CustomerDto>
    {
        public void Configure(EntityTypeBuilder<CustomerDto> builder)
        {
            builder.Property(x => x.ContactName).HasMaxLength(100);
            builder.Property(x => x.CompanyName).HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x=>x.Phone).HasMaxLength(100);
            builder.Property(x => x.Nots).HasMaxLength(500);
        }
    }
}
