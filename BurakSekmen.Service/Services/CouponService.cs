using AutoMapper;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Service.Services
{
    public class CouponService : Service<Coupon>, ICouponService
    {
      
        public CouponService(IGenericRepository<Coupon> genericRepository, IUnitOfWorks unitOfWorks) : base(genericRepository, unitOfWorks)
        {
            
        }

     
    }
}
