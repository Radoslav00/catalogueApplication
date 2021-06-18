using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadCarData()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetCars(), "CarID", "Make");
            }
        }
        public static SelectList LoadZoneData()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetZones(), "ZoneID", "ZoneName");
            }
        }
    }
}