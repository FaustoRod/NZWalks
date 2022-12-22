namespace NZWalksApi.Services.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        bool Add(T region);
        bool Update(T region);
        bool Delete(Guid Id);
        T GetById(Guid Id);
    }
}
