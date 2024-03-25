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
    public class TaxRepository : GenericRepository<Tax>, ITaxRepository
    {
        public TaxRepository(AppDbContext context) : base(context)
        {
        }
    }
}
