using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.UnitOfWorks;
using BurakSekmen.Repository.Context;

namespace BurakSekmen.Repository.UnitOfWorks
{
    public class UnitOfWorks:IUnitOfWorks
    {
        private readonly AppDbContext _context;

        public UnitOfWorks(AppDbContext context)
        {
            _context = context;
        }


        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
