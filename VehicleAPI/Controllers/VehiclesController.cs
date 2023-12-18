using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Repositories;

namespace VehicleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleRepository _repository;


        public VehiclesController(VehicleRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet("Id-Colors")]
        public IActionResult GetAllVehicles()
        {
            var allVehicles = _repository.GetAll();
            return Ok(allVehicles);
        }

        
        
        [HttpGet("Cars")]
        public IActionResult GetCarsByColor(string color)
        {
            var cars = _repository.GetByColor(color);
            return Ok(cars.OfType<Car>());
        }

        
        
        [HttpGet("Buses")]
        public IActionResult GetBusesByColor(string color)
        {
            var buses = _repository.GetByColor(color);
            return Ok(buses.OfType<Bus>());
        }

       
        
        [HttpGet("Boats")]
        public IActionResult GetBoatsByColor(string color)
        {
            var boats = _repository.GetByColor(color);
            return Ok(boats.OfType<Boat>());
        }

       
        
        [HttpPost("{id}/Headlights")]
        public IActionResult ToggleHeadlights(int id)
        {
            var car = _repository.GetCarById(id);
            if (car == null)
                return NotFound();

            car.Headlights = !car.Headlights;
            _repository.Update(car);
            string headlightsStatus = car.Headlights ? "açık" : "kapalı";

            //Arabanın far durumu false ise butona basıldığında açılır, true ise butona basıldığında kapanır.

            return Ok($"{id} nolu aracın farları {headlightsStatus} ");
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _repository.GetById(id);
            if (vehicle == null)
                return NotFound();

            _repository.Delete(id);

            return Ok($"Araç {id} silindi");
        }
    }
}
