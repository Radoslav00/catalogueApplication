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
    public class PartsManagementService
    {
        private ProjectDbContext2 context = new ProjectDbContext2();
        public List<PartDTO> Get()
        {
            List<PartDTO> partsDTO = new List<PartDTO>();
            foreach (var item in context.Parts.ToList())
            {
                partsDTO.Add(new PartDTO
                {
                    PartID = item.PartID,
                    PartName = item.PartName,
                    Price = item.Price,
                    CatalogueNumber = item.CatalogueNumber,

                    ZoneID = item.ZoneID,
                    Zone = new ZoneDTO
                    {
                        ZoneID = item.ZoneID,
                        ZoneName = item.Zone.ZoneName
                    },

                    CarID = item.CarID,
                    Car = new CarDTO
                    {
                        CarID = item.CarID,
                        Make = item.Car.Make,
                        Manufacturer = item.Car.Manufacturer,
                        Color = item.Car.Color,
                        Fuel = item.Car.Fuel
                    }

                });
            }
            return partsDTO;
        }
        public PartDTO GetById(int id)
        {
            Part item = context.Parts.Find(id);
            PartDTO partDTO = new PartDTO
            {
                PartID = item.PartID,
                PartName = item.PartName,
                Price = item.Price,
                CatalogueNumber = item.CatalogueNumber,

                ZoneID = item.ZoneID,
                Zone = new ZoneDTO
                {
                    ZoneID = item.ZoneID,
                    ZoneName = item.Zone.ZoneName
                },

                CarID = item.CarID,
                Car = new CarDTO
                {
                    CarID = item.CarID,
                    Make = item.Car.Make,
                    Manufacturer = item.Car.Manufacturer,
                    Color = item.Car.Color,
                    Fuel = item.Car.Fuel
                }
            };
            return partDTO;
        }
        public bool Set(PartDTO partDTO)
        {
            try
            {
                Part part = new Part
                {
                    PartID = partDTO.PartID,
                    PartName = partDTO.PartName,
                    Price = partDTO.Price,
                    CatalogueNumber = partDTO.CatalogueNumber,
                    ZoneID = partDTO.ZoneID,
                    CarID = partDTO.CarID
                };
                context.Parts.Add(part);
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
                Part part = context.Parts.Find(id);
                context.Parts.Remove(part);
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
