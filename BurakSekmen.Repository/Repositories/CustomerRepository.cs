using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;

namespace BurakSekmen.Repository.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
