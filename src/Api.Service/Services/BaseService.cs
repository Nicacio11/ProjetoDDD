using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Infraestructure.Data.Repositories;

namespace Api.Service.Services
{
    public abstract class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _baseRepository;
        public BaseService(IRepository<T> repository)
        {
            _baseRepository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _baseRepository.ExistsAsync(id);
        }

        public async Task<T> Get(Guid id)
        {
            return await _baseRepository.GetAsync(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _baseRepository.GetAsync();
        }

        public async Task<T> Post(T entity)
        {
            return await _baseRepository.InsertAsync(entity);
        }

        public async Task<T> Put(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
