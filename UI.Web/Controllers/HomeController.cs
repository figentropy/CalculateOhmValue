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
        public JsonResult CalculateOhms(string banda, string bandb, string bandc, string bandd)
        {
            Services.UseCase.ResistorActions resistor = new Services.UseCase.ResistorActions();
            int result = -1;

            result = resistor.CalculateOhmValue(banda, bandb, bandc, bandd);


            return Json(result);

        }
    }
}