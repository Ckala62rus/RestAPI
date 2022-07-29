using Microsoft.EntityFrameworkCore;
using Moq;
using RestApi.DAL;
using RestApi.DAL.Interfaces;
using RestApi.DAL.Repositories;
using RestApi.Domain.Entity;
using RestApi.Domain.Enum;
using RestApi.Service.CarService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RestApi.Tests
{
    public class TestExample
    {
        public readonly CarService _carService;
        public TestExample()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TESTDB");
            var _context = new ApplicationDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            
            _carService = new CarService(new CarRepository(_context));
        }

        [Fact]
        public async Task CheckNotExistCarInDatabase()
        {
            var car = await _carService.GetCar(1);
            Assert.Null(car);
        }

        [Fact]
        public async Task CheckCreateNewCar()
        {
            // Arrange
            
            var newCar = new Car
            {
                Name = "BMW",
                Model = "X5",
                DateCreate = DateTime.Now,
                Speed = 250,
                TypeCar = TypeCar.Sedan
            };

            // Act

            _carService.Create(newCar);
            var notExistCar = await _carService.GetCar(2);
            var existCar = await _carService.GetCar(1);

            // Assert

            Assert.Null(notExistCar);
            Assert.Equal(1, existCar.Id);
            Assert.Equal("BMW", existCar.Name);
            Assert.Equal(250, existCar.Speed);
            Assert.Null(existCar.Description);
        }

        [Fact]
        public async Task GetCarsTestAsync()
        {
            // arrange
            var carRepository = new Mock<ICarRepository>();
            //It.IsAny<int>())
            carRepository.Setup(x => x.Select()).Returns(GetCarMock());
            var carService = new CarService(carRepository.Object);

            // act
            var actual = await carService.GetCars();

            // assert
            Assert.NotEmpty(actual);
        }

        public async Task<List<Car>> GetCarMock()
        {
            var car = new Car
            {
                Id = 1,
                Name = "BMW",
                Model = "X5",
                DateCreate = DateTime.Now,
                Speed = 250,
                TypeCar = TypeCar.Sedan
            };

            var car2 = new Car
            {
                Id = 2,
                Name = "Mazda",
                Model = "3",
                DateCreate = DateTime.Now,
                Speed = 200,
                TypeCar = TypeCar.Sedan
            };

            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car2);

            return carList;
        }
    }
} 
