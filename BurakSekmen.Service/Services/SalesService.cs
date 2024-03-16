using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace BurakSekmen.Service.Services
{
    public class SalesService:Service<Sales>,ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public SalesService(IGenericRepository<Sales> genericRepository, IUnitOfWorks unitOfWorks, ISalesRepository salesRepository, IMapper mapper) : base(genericRepository, unitOfWorks)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }


        public Task<IEnumerable<Sales>> GetPersonSalesWithIncludesAsync(int personId, bool tracking = true, params Expression<Func<Sales, object>>[] includes)
        {
            return _salesRepository.GetPersonSalesWithIncludesAsync(personId, tracking, includes);
        }

        public Task<IEnumerable<Sales>> ListPersonSales(bool tracking = true, params Expression<Func<Sales, object>>[] includes)
        {
            return _salesRepository.ListPersonSales(tracking, includes);
        }

        public Task<bool> MakeSale(int productId, int quantity)
        {
            return _salesRepository.MakeSale(productId, quantity);

        }

        public Task<bool> UpdateStockAsync(SalesDto salesDto)
        {
            return _salesRepository.UpdateStockAsync(salesDto);
        }
    }
}
