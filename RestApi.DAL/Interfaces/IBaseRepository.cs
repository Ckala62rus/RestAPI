using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        Task<T> Get(int id);
        Task<List<T>> Select();
        bool Delete(T entity);
        Task<T> Update(T entity);
    }
}
