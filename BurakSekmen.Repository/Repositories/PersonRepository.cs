using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;

namespace BurakSekmen.Repository.Repositories
{
    public class PersonRepository : GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
