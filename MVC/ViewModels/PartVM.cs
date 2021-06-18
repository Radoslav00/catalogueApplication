using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class PartVM
    {
        [ScaffoldColumn(false)]
        public int PartID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Part name can't be that long.")]
        public string PartName { get; set; }
        [Required]
        [Range(1, 9999.99, ErrorMessage = "Price must be between 1 and 9999.99")]
        public double Price { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Catalogue number must have 10 digits")]
        [MinLength(10, ErrorMessage = "Catalogue number must have 10 digits")]
        public string CatalogueNumber { get; set; }

        [Required]
        public int ZoneID { get; set; }
        public virtual ZoneVM Zone { get; set; }

        [Required]
        public int CarID { get; set; }
        public virtual CarVM Car { get; set; }

        public PartVM() { }

        public PartVM(PartDTO partDTO)
        {
            PartID = partDTO.PartID;
            PartName = partDTO.PartName;
            Price = partDTO.Price;
            CatalogueNumber = partDTO.CatalogueNumber;
            ZoneID = partDTO.ZoneID;
            Zone = new ZoneVM
            {
                ZoneID = partDTO.ZoneID,
                ZoneName = partDTO.Zone.ZoneName
            };
            CarID = partDTO.CarID;
            Car = new CarVM
            {
                CarID = partDTO.CarID,
                Make = partDTO.Car.Make,
                Manufacturer = partDTO.Car.Manufacturer,
                Color = partDTO.Car.Color,
                Fuel = partDTO.Car.Fuel
            };
        }
    }
}