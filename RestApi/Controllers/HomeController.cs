using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.DAL.Interfaces;
using RestApi.Domain.Entity;
using RestApi.Models;
using RestApi.Service.CarService;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
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

            return View();
        }

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
