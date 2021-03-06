using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGH_MOSA.Filters;

namespace SGH_MOSA.Controllers
{
    public class HomeController : Controller
    {
        [AuthSAP("Adminsitrador", "Operador")]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        [AuthSAP("Adminsitrador", "Operador")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [AuthSAP("Adminsitrador", "Operador")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
