using RestApi.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Car GetByName(string name);
        Task<List<Car>> CarByPrice();
    }
}
