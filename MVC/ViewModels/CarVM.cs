using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class CarVM
    {
        [ScaffoldColumn(false)]
        public int CarID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Car make must be maximum 25 letters")]
        public string Make { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Car manufacturer must be maximum 25 letters")]
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        [Required]

        [StringLength(10, ErrorMessage = "Car fuel type must be maximum 10 letters")]
        public string Fuel { get; set; }

        public CarVM() { }

        public CarVM(CarDTO carDTO)
        {
            CarID = carDTO.CarID;
            Make = carDTO.Make;
            Manufacturer = carDTO.Manufacturer;
            Color = carDTO.Color;
            Fuel = carDTO.Fuel;
        }
    }
}