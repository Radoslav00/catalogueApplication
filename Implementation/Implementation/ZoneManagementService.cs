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
    public class ZoneManagementService
    {
        private ProjectDbContext2 context = new ProjectDbContext2();
        public List<ZoneDTO> Get()
        {
            List<ZoneDTO> zonesDTO = new List<ZoneDTO>();
            foreach (var item in context.Zones.ToList())
            {
                zonesDTO.Add(new ZoneDTO
                {
                    ZoneID = item.ZoneID,
                    ZoneName = item.ZoneName
                });
            }
            return zonesDTO;
        }
        public ZoneDTO GetById(int id)
        {
            Zone zone = context.Zones.Find(id);
            ZoneDTO zoneDTO = new ZoneDTO
            {
                ZoneID = zone.ZoneID,
                ZoneName = zone.ZoneName
            };
            return zoneDTO;
        }
        public bool Set(ZoneDTO zoneDTO)
        {
            try
            {
                Zone zone = new Zone
                {
                    ZoneID = zoneDTO.ZoneID,
                    ZoneName = zoneDTO.ZoneName
                };
                context.Zones.Add(zone);
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
                Zone zone = context.Zones.Find(id);
                context.Zones.Remove(zone);
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
