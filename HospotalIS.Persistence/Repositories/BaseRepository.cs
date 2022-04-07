using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInfoSystem.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HositalS.Persistence.Repositories
{
    public partial class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly HospitalISDbContext _context;

        public BaseRepository(HospitalISDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        public async Task DeleteAsync(T entiry)
        {
            _context.Set<T>().Remove(entiry);
            await _context.SaveChangesAsync(); 
      
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
