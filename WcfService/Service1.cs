using System;
using System.Collections.Generic;
using ApplicationService.DTOs;
using ApplicationService.Implementation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region "Position"
        private PositionManagementService positionService = new PositionManagementService();
        public List<PositionDTO> GetPositions()
        {
            return positionService.Get();
        }

        public PositionDTO GetPositionById(int id)
        {
            return positionService.GetById(id);
        }

        public string SetPosition(PositionDTO position)
        {
            if (positionService.Set(position))
            {
                return "Position saved successfuly!";
            }
            else
            {
                return "Position could not be saved!";
            }
        }

        public string DeletePosition(int id)
        {
            if (positionService.Delete(id))
            {
                return "Position deleted successfuly!";
            }
            else
            {
                return "Position could not be deleted!";
            }
        }

        #endregion
        #region "Person"
        private PersonManagementService personService = new PersonManagementService();
        public List<PersonDTO> GetPerson()
        {
            return personService.Get();
        }

        public PersonDTO GetPersonById(int id)
        {
            return personService.GetById(id);
        }

        public string SetPerson(PersonDTO person)
        {
            if (personService.Set(person))
            {
                return "Person is saved successfuly!";
            }
            else
            {
                return "Person could not be saved!";
            }
        }

        public string DeletePerson(int id)
        {
            if (personService.Delete(id))
            {
                return "Person is deleted successfuly!";
            }
            else
            {
                return "Person could not be deleted!";
            }
        }
        public List<PersonDTO> GetPersonByUsername(string Username)
        {
            return personService.GetByUsername(Username);
        }

        public bool Authorize (PersonDTO personDTO)
        {
            List<PersonDTO> personDTOs = personService.GetByUsername(personDTO.Username);

            foreach (var item in personDTOs)
            {
                if (item.Username.Equals(personDTO.Username))
                {
                    return item.Password == personDTO.Password;
                }
            }

            return false;
        }

        #endregion
        #region "Cars"
        private CarManagementService carService = new CarManagementService();
        public List<CarDTO> GetCars()
        {
            return carService.Get();
        }

        public CarDTO GetCarsById(int id)
        {
            return carService.GetById(id);
        }

        public string SetCar(CarDTO car)
        {
            if (carService.Set(car))
            {
                return "Car saved successfully!";
            }
            else
            {
                return "Car could not be saved!";
            }
        }

        public string DeleteCar(int id)
        {
            if (carService.Delete(id))
            {
                return "Car deleted successfully!";
            }
            else
            {
                return "Car could not be deleted!";
            }
        }
        #endregion
        #region "Zones"
        private ZoneManagementService zoneService = new ZoneManagementService();
        public List<ZoneDTO> GetZones()
        {
            return zoneService.Get();
        }

        public ZoneDTO GetZoneById(int id)
        {
            return zoneService.GetById(id);
        }

        public string SetZone(ZoneDTO zone)
        {
            if (zoneService.Set(zone))
            {
                return "Zone is saved successfully!";
            }
            else
            {
                return "Zone could not be saved!";
            }
        }

        public string DeleteZone(int id)
        {
            if (zoneService.Delete(id))
            {
                return "Zone is deleted successfully!";
            }
            else
            {
                return "Zone could not be deleted!";
            }
        }
        #endregion
        #region "Parts"
        private PartsManagementService partService = new PartsManagementService();
        public List<PartDTO> GetParts()
        {
            return partService.Get();
        }

        public PartDTO GetPartById(int id)
        {
            return partService.GetById(id);
        }

        public string SetPart(PartDTO part)
        {
            if (partService.Set(part))
            {
                return "Part is saved successfully!";
            }
            else
            {
                return "Part could not be saved!";
            }
        }

        public string DeletePart(int id)
        {
            if (partService.Delete(id))
            {
                return "Part is deleted successfully!";
            }
            else
            {
                return "Part could not be deleted!";
            }
        }
        #endregion
    }
}
