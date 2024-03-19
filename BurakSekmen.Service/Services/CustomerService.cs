using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;

namespace BurakSekmen.Service.Services
{
    public class CustomerService:Service<Customer>,ICustomerService
    {
        public CustomerService(IGenericRepository<Customer> genericRepository, IUnitOfWorks unitOfWorks) : base(genericRepository, unitOfWorks)
        {
        }
    }
}
