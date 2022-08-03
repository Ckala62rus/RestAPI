using RestApi.DAL.Interfaces;
using RestApi.Domain.Entity;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.Service.CarService
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetCars()
        {
            Log.Information("Get and return all cars");
            return await _carRepository.Select();
        }

        public Car Create(Car car)
        {
            _carRepository.Create(car);
            return car;
        }

        public async Task<Car> GetCar(int id)
        {
            return await _carRepository.Get(id);
        }

        public bool Delete(Car Entity)
        {
            return _carRepository.Delete(Entity);
        }

        public async Task<Car> Update(Car entity)
        {
            await _carRepository.Update(entity);
            return entity;

        }

        public Car GetCarByName(string name)
        {
            return _carRepository.GetByName(name);
        }
    }
}
