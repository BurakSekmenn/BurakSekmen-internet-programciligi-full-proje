using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;

namespace BurakSekmen.Service.Services
{
    internal class PersonService:Service<Person>,IPersonService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public PersonService(IGenericRepository<Person> genericRepository, IUnitOfWorks unitOfWorks, IMapper mapper, ICategoryRepository categoryRepository) : base(genericRepository, unitOfWorks)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
    }
}
