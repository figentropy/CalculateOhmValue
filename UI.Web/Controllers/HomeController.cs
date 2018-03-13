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
            Services.UseCase.ResistorActions resistor = new Services.UseCase.ResistorActions(new Infrastructure.ExceptionManager.FileLogger());
            //double resistance = -1;
            //double multiplier = 0;
            //double tolerance = 0;
            //double maxresistance = 0;
            //double minresistance = 0;
            //int ohmValue = 0;

            var results = resistor.GetAllComputedValues(colorcodes.banda, colorcodes.bandb, colorcodes.bandc, colorcodes.bandd);
            
            //ohmValue = resistor.CalculateOhmValue(colorcodes.banda, colorcodes.bandb, colorcodes.bandc, colorcodes.bandd);
            //multiplier = resistor.GetMultiplier(colorcodes.bandc);
            //resistance = resistor.GetResistance();
            //tolerance = resistor.GetTolerance(colorcodes.bandd);
            //maxresistance = resistor.GetMaxResistance(resistance, tolerance);
            //minresistance = resistor.GetMinResistance(resistance, tolerance);


            return Json( new { Resistance = results.resistance, Tolerance = results.tolerance,
                MaxResistance = results.maxresistance, MinResistance = results.minresistance });

        }
    }
}