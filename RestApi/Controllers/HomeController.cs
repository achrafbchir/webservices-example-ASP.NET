using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}