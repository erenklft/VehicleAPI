using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public class VehicleRepository
    {
        private readonly List<Vehicle> vehicles = new List<Vehicle>();

        public VehicleRepository()
        {
            //ARAÇ HAVUZUNU OLUŞTURALIM.

            Add(new Car { Id = 1, Color = "Red", Headlights = false, Wheels = 4 });
            Add(new Car { Id = 2, Color = "Black", Headlights = false, Wheels = 4 });
            Add(new Bus { Id = 3, Color = "Blue"});
            Add(new Bus { Id = 4, Color = "Yellow" });
            Add(new Boat { Id = 5, Color = "White"});
            Add(new Boat { Id = 6, Color = "Orange" });
        }

        public List<Vehicle> GetAll() => vehicles;

        public List<Vehicle> GetByColor(string color) => vehicles.FindAll(v => v.Color.ToLower() == color.ToLower());

        public Vehicle GetById(int id) => vehicles.Find(v => v.Id == id);
        public Car GetCarById(int id) => vehicles.OfType<Car>().FirstOrDefault(c => c.Id == id);

        public void Add(Vehicle vehicle) => vehicles.Add(vehicle);

        public void Update(Car car)
        {
          
        }

        public void Delete(int id) => vehicles.RemoveAll(v => v.Id == id);
    }
}
