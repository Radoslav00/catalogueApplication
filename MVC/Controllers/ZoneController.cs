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
    public class ZoneController : Controller
    {
        // GET: Zone
        public ActionResult Index()
        {
            List<ZoneVM> zonesVM = new List<ZoneVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetZones())
                {
                    zonesVM.Add(new ZoneVM(item));
                }
            }
            return View(zonesVM);
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(ZoneVM zoneVM)
        {
            try
            {
                using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                {
                    ZoneDTO zoneDTO = new ZoneDTO
                    {
                        ZoneID = zoneVM.ZoneID,
                        ZoneName = zoneVM.ZoneName
                    };
                    service.SetZone(zoneDTO);
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
            ZoneVM zoneVM = new ZoneVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                ZoneDTO zoneDTO = service.GetZoneById(id);
                zoneVM = new ZoneVM(zoneDTO);
            }

            return View(zoneVM);
        }
        //endaction
        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteZone(id);
            }
            return RedirectToAction("Index");
        }
    }
}