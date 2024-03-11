﻿using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;
using BurakSekmen.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BurakSekmen.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IUnitOfWorks _unitOfWorks;

        public Service(IGenericRepository<T> genericRepository, IUnitOfWorks unitOfWorks)
        {
            _genericRepository = genericRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var datacontrol = await _genericRepository.GetByIdAsync(id);

            if (datacontrol == null)
            {
                throw new NotFoundExecption($"{typeof(T).Name}({id}) Not Found");
            }
            return datacontrol;
        }

        public IQueryable<T> GetAll()
        {
            return  _genericRepository.GetAll();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.AnyAsync(expression);
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _genericRepository.AddAsync(entity);
                await _unitOfWorks.CommitAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
            }

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            await _genericRepository.AddRangeAsync(entity);
            await _unitOfWorks.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
             
             _genericRepository.Update(entity);
             entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
             await _unitOfWorks.CommitAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _genericRepository.Remove(entity);
            await _unitOfWorks.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
           _genericRepository.RemoveRange(entity);
           await _unitOfWorks.CommitAsync();
        }
    }
}
