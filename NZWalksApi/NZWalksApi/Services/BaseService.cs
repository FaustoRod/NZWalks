using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        public BaseService()
        {

        }
        public bool Add(T region)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T region)
        {
            throw new NotImplementedException();
        }
    }
}
