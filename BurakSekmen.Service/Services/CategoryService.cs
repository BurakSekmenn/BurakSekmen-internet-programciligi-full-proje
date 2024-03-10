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
    public class CategoryService:Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> genericRepository, IUnitOfWorks unitOfWorks, ICategoryRepository categoryRepository, IMapper mapper) : base(genericRepository, unitOfWorks)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
    }
}
