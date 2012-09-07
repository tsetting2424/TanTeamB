using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SoftwareEngineering.Models;

namespace SoftwareEngineering.Controllers
{

    public class AccountController : Controller
    {
        //
        // GET: /Account/Index

        public ActionResult Index()
        {
            
            return View();
        }

        //
        // GET: /Account/Login

       
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult LoginAccount(string UserName, string Password)
        {
            
            LoginModel model = new LoginModel();
            model.UserName = UserName;
            model.Password = Password;

            if (model.UserName == "tony")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return PartialView("LoginAccount", model);
            }
        }

       
    }
}
