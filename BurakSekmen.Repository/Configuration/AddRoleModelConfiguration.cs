using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakSekmen.Repository.Configuration
{
    public class AddRoleModelConfiguration: IEntityTypeConfiguration<AddRoleModel>
    {
        public void Configure(EntityTypeBuilder<AddRoleModel> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Role).IsRequired();
        }
    }
}
