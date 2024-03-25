using BurakSekmen.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Repository.Configuration
{
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.Property(x => x.TaxName).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.TaxName); // Index Tanımladım. Search Ederken sonra lazım olur. Apide Sorgu atarken id göre atacağım ama!
            builder.Property(x => x.Rate).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.PaymetDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            
        }
    }
}
