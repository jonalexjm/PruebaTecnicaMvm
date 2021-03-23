using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radicaciones.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(long id);
    }
}