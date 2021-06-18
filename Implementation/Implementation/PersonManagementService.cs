using System;
using ApplicationService.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities;

namespace ApplicationService.Implementation
{
    public class PersonManagementService
    {
        private ProjectDbContext2 context = new ProjectDbContext2();
        public List<PersonDTO> Get()
        {
            List<PersonDTO> personDTO = new List<PersonDTO>();
            foreach (var item in context.Person.ToList())
            {
                personDTO.Add(new PersonDTO
                {
                    PersonID = item.PersonID,
                    Username = item.Username,

                    PositionID = item.PositionID
                });
            }
            return personDTO;

        }
        public PersonDTO GetById(int id)
        {
            Person person = context.Person.Find(id);
            PersonDTO personDTO = new PersonDTO
            {
                PersonID = person.PersonID,
                Username = person.Username,

                PositionID = person.PositionID
            };

            return personDTO;
        }
        public bool Set(PersonDTO personDTO)
        {
            try
            {
                Person person = new Person
                {
                    PersonID = personDTO.PersonID,
                    Username = personDTO.Username,
                    Password = personDTO.Password,

                    PositionID = personDTO.PositionID
                };
                context.Person.Add(person);
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
                Person person = context.Person.Find(id);

                context.Person.Remove(person);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<PersonDTO> GetByUsername(string Username)
        {
            List<PersonDTO> personDTOs = new List<PersonDTO>();
            foreach (var item in context.Person.ToList())
            {
                if(item.PersonID!=0 && item.Username!=null)
                if (item.Username.StartsWith(Username))
                {
                    personDTOs.Add(new PersonDTO
                    {
                        PersonID = item.PersonID,
                        Username = item.Username,
                        Password = item.Password,
                        PositionID = item.PositionID
                    });
                }
            }
            return personDTOs;
        }
    }
}
