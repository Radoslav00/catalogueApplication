using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class ZoneVM
    {
        [ScaffoldColumn(false)]
        public int ZoneID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Zone name can't be that long!")]
        public string ZoneName { get; set; }

        public ZoneVM() { }

        public ZoneVM(ZoneDTO zoneDTO)
        {
            ZoneID = zoneDTO.ZoneID;
            ZoneName = zoneDTO.ZoneName;
        }
    }
}