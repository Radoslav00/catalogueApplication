using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class PositionVM
    {
        [ScaffoldColumn(false)]
        public int PositionID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Position title can't be that long.")]
        [Display(Name ="Position")]
        public string PositionTitle { get; set; }


        public PositionVM() { }

        public PositionVM(PositionDTO positionDTO)
        {
            PositionID = positionDTO.PositionID;
            PositionTitle = positionDTO.PositionTitle;
        }
    }
}