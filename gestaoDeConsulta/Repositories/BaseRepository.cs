using gestaoDeConsulta.Context;
using gestaoDeConsulta.Models;
using gestaoDeConsulta.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gestaoDeConsulta.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<T> UpdateAsync(T model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return model;
        }
        public async Task DeleteAsync(Guid id)
        {

            var obj = await GetByIdAsync(id);

            if ( obj != null ) {
                _context.Set<T>().Remove(obj);
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
