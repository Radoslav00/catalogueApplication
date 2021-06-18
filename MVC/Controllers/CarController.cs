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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            List<CarVM> carsVM = new List<CarVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetCars())
                {
                    carsVM.Add(new CarVM(item));
                }
            }
            return View(carsVM);
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(CarVM carVM)
        {
            try
            {
                using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                {
                    CarDTO carDTO = new CarDTO
                    {
                        CarID = carVM.CarID,
                        Make = carVM.Make,
                        Manufacturer = carVM.Manufacturer,
                        Color = carVM.Color,
                        Fuel = carVM.Fuel
                    };
                    service.SetCar(carDTO);
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
            CarVM carVM = new CarVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                CarDTO carDTO = service.GetCarsById(id);
                carVM = new CarVM(carDTO);
            }

            return View(carVM);
        }
        //endaction
        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteCar(id);
            }
            return RedirectToAction("Index");
        }
    }
}