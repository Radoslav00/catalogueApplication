using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class CarManagementService
    {
        private ProjectDbContext2 context = new ProjectDbContext2();
        public List<CarDTO> Get()
        {
            List<CarDTO> carsDTO = new List<CarDTO>();
            foreach (var item in context.Cars.ToList())
            {
                carsDTO.Add(new CarDTO
                {
                    CarID = item.CarID,
                    Make = item.Make,
                    Manufacturer = item.Manufacturer,
                    Color = item.Color,
                    Fuel = item.Fuel
                });
            }
            return carsDTO;
        }
        public CarDTO GetById(int id)
        {
            Car car = context.Cars.Find(id);
            CarDTO carDTO = new CarDTO
            {
                CarID = car.CarID,
                Make = car.Make,
                Manufacturer = car.Manufacturer,
                Color = car.Color,
                Fuel = car.Fuel
            };
            return carDTO;
        }
        public bool Set(CarDTO carDTO)
        {
            try
            {
                Car car = new Car
                {
                    CarID = carDTO.CarID,
                    Make = carDTO.Make,
                    Manufacturer = carDTO.Manufacturer,
                    Color = carDTO.Color,
                    Fuel = carDTO.Fuel
                };
                context.Cars.Add(car);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Car car = context.Cars.Find(id);
                context.Cars.Remove(car);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
