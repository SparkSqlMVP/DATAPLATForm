using Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIPortalV2.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Airport()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AirportList(string contrycode)
        {
            var airportlocation = AirportLocation.Airports("china");
            return Json(new { data = airportlocation }, JsonRequestBehavior.AllowGet);
        }
       
    }
}