using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Repository.Repositories
{
    public class CouponRepository : GenericRepository<Coupon>,ICouponRepository
    {
        public CouponRepository(AppDbContext context) : base(context)
        {
        }
    }
}
