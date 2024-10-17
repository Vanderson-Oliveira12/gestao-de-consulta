using gestaoDeConsulta.Models;

namespace gestaoDeConsulta.Repositories.Interface
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(Guid id);
    }
}
