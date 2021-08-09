using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<bool> Delete(Guid id);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> Get();
        Task<bool> Exists(Guid id);
    }
}
