using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareEngineering.Controllers
{
    public class ManagerController : Controller
    {
        //gets Create User View
        public ActionResult CreateAccount()
        {
            return View();
        }

        //gets UpdateUser view
        public ActionResult UpdateAccounts()
        {
            return View();
        }

        //gets reports View
        public ActionResult reports()
        {
            return View();
        }

        public ActionResult ManagerHome()
        {
            return View();
        }

    }
}
