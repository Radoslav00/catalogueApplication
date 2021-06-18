using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class PartController : Controller
    {
        // GET: Part
        public ActionResult Index()
        {
            List<PartVM> partsVM = new List<PartVM>();
            using(ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetParts())
                {
                    partsVM.Add(new PartVM(item));
                }
            }
            return View(partsVM);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cars = Helpers.LoadDataUtilities.LoadCarData();
            ViewBag.Zones = Helpers.LoadDataUtilities.LoadZoneData();


            return View();
        }
        [HttpPost]
        public ActionResult Create(PartVM partVM)
        {
            try
            {
                using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                {
                    PartDTO partDTO = new PartDTO
                    {
                        PartID = partVM.PartID,
                        PartName = partVM.PartName,
                        Price = partVM.Price,
                        CatalogueNumber = partVM.CatalogueNumber,
                        CarID = partVM.CarID,
                        ZoneID = partVM.ZoneID
                    };
                    service.SetPart(partDTO);
                }


                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
        //endaction
        public ActionResult Details(int id)
        {
            PartVM partVM = new PartVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                PartDTO partDTO = service.GetPartById(id);
                partVM = new PartVM(partDTO);
            }

            return View(partVM);
        }
        //endaction
        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeletePart(id);
            }
            return RedirectToAction("Index");

        }
    }
}