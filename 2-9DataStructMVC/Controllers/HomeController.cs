using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_9DataStructMVC.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu/");
        }
    }
}