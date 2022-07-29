using RestApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Service.CarService
{
    public interface ICarService
    {
        Task<List<Car>> GetCars();
        Car Create(Car car);
        Task<Car> GetCar(int id);
        bool Delete(Car Entity);
        Task<Car> Update(Car entity);
    }
}
