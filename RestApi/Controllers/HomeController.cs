using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.DAL.Interfaces;
using RestApi.Domain.Entity;
using RestApi.Models;
using RestApi.Service.CarService;
using Serilog;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;

        public HomeController(
            ILogger<HomeController> logger, 
            ICarRepository carRepository, 
            ICarService carService
        )
        {
            _logger = logger;
            _carRepository = carRepository;
            _carService = carService;
        }

        [HttpPost("car")]
        public async Task<IActionResult> Create(Car car)
        {
            _carService.Delete(await _carService.GetCar(2));
            _carRepository.Create(car);
            return Json(car);
        }

        //[HttpGet("car")]
        public async Task<IActionResult> Index()
        {
            //var newCar = new Car
            //{
            //    Name = "BMW",
            //    Model = "X5",
            //    DateCreate = DateTime.Now,
            //    Speed = 250,
            //    TypeCar = TypeCar.Sedan
            //};

            //_carRepository.Create(newCar);

            //var car = _carRepository.GetByName("BMW");

            //car.Description = "Show me the moeny";

            //await _carService.Update(car);

            //_carService.Delete(car);

            //var cars = await _carRepository.Select();

            try
            {
                var msg = "start loggin. HomeController - Action Index";
                Log.Information($"{msg}");

                var cars = await _carService.GetCars();

                Log.Information($"Count records from database ({cars.Count})");
                var a = 1;
                var b = 0;
                var c = a / b;
            } 
            catch (Exception ex)
            {
                Log.Fatal(ex.ToString() + "\n");
            }
            
            return View();
        }

        //[HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
