using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestructure.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var item = await this.GetAsync(id);
                if (item == null)
                    return false;

                _dataSet.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(item => item.Id == id);
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }
                entity.CreatedAt = DateTime.UtcNow;
                await _dataSet.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var item = await this.GetAsync(entity.Id);
                if (item == null)
                {
                    throw new Exception("Item não encontrado!");
                }
                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = item.CreatedAt;

                _context.Entry(item).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return entity;
        }
    }
}
