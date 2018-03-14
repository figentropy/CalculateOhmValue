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
        public JsonResult CalculateOhms(List<string> selectedColors)
        {
            Services.UseCase.ResistorComputations resistor = new Services.UseCase.ResistorComputations(new Infrastructure.ExceptionManager.FileLogger());

            
            // This section will return the computation results for a 4 strip resistor
            if (selectedColors.Count == 4)
            {
                var results = resistor.GetAllComputedValues(selectedColors[0], selectedColors[1], selectedColors[2], selectedColors[3]);

                return Json(new
                {
                    Resistance = results.resistance,
                    Tolerance = results.tolerance,
                    MaxResistance = results.maxresistance,
                    MinResistance = results.minresistance
                });

            }


            // If we wanted to design for the other resistor types (5,6 band) we could place the code in the following
            // section for count = 5,6... although I would refactor this by modifying the IOhmValueCalculator interface
            // to accomodate all the resistor types.
            if (selectedColors.Count == 5)
            {

                // 5,6 color resistor code would be implemented here...

                return Json(new
                {
                    Resistance = 0,
                    Tolerance = 0,
                    MaxResistance = 0,
                    MinResistance = 0
                });

            }


            // -------------------------------------------------


            // If an undefined resistor type is submitted, return blank results.
            return Json(new
            {
                Resistance = 0,
                Tolerance = 0,
                MaxResistance = 0,
                MinResistance = 0
            });


        }
    }
}