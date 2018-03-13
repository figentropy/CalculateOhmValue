using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public JsonResult CalculateOhms(Domain.Entity.ColorCodes colorcodes)
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.FileLogger());

            var results = resistor.GetAllComputedValues(colorcodes.banda, colorcodes.bandb, colorcodes.bandc, colorcodes.bandd);
            

            return Json( new { Resistance = results.resistance, Tolerance = results.tolerance,
                MaxResistance = results.maxresistance, MinResistance = results.minresistance });

        }
    }
}