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
    public class PositionManagementService
    {
        private ProjectDbContext2 context = new ProjectDbContext2();
        public List<PositionDTO> Get()
        {
            List<PositionDTO> positionDTOs = new List<PositionDTO>();

            foreach (var item in context.Positions.ToList())
            {
                positionDTOs.Add(new PositionDTO
                {
                    PositionID = item.PositionID,
                    PositionTitle = item.PositionTitle
                });
            }

            return positionDTOs;
        }

        public PositionDTO GetById(int id)
        {
            Position pos = context.Positions.Find(id);

            PositionDTO positionDTO = new PositionDTO
            {
                PositionID = pos.PositionID,
                PositionTitle = pos.PositionTitle
            };

            return positionDTO;
        }

        public bool Set(PositionDTO positionDTO)
        {
            try
            {
                Position position = new Position
                {
                    PositionID = positionDTO.PositionID,
                    PositionTitle = positionDTO.PositionTitle
                };
                context.Positions.Add(position);
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
                Position position = context.Positions.Find(id);
                context.Positions.Remove(position);
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
