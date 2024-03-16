using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakSekmen.Repository.Configuration
{
    public class IdentityConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>,
        IEntityTypeConfiguration<IdentityUserRole<string>>,
        IEntityTypeConfiguration<IdentityUserClaim<string>>,
        IEntityTypeConfiguration<IdentityUserToken<string>>,
        IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.HasKey(p => p.UserId);
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
       
            builder.HasKey(p => new { p.UserId, p.RoleId });
        }

        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
           
        }

        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
       
            builder.HasKey(p => p.UserId);
        }

        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
     
        }
    }
}
