using NZWalksApi.Models;

namespace NZWalksApi.Services.Interfaces
{
    public interface IBaseService<T>
    where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(Guid id,T model);
        Task<T> DeleteAsync(Guid Id);
        Task<T> GetByIdAsync(Guid Id);
    }
}
