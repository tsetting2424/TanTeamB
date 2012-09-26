using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SoftwareEngineering.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



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


        // this action is called by the login button on the Login page
        //it is sent the user input for user name and password
        //this then connects to the DB and queries the DB for the user input
        // from here the DB sends back if the user is in the DB if it is 
        //it checks to see what the users role is and sends them to the
        //corrosponding Home page
        public ActionResult LoginAccount(string UserName, string Password)
        {
            LoginModel model = new LoginModel();
            model.UserName = UserName;
            model.Password = Password;
            try
            {
                string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SEWebApp"].ConnectionString;
                SqlConnection connect = new SqlConnection(connString);
                SqlDataReader reader = null;
                connect.Open();

                SqlCommand cmd = new SqlCommand("select role from tblUsers where FirstName = @Name", connect);
                cmd.Parameters.Add("@Name", model.UserName);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = reader.GetString(0);
                    if (role == "user")
                    {
                        return RedirectToAction("ManagerHome", "Manager");
                    }
                    else if (role == "manager")
                    {
                        return RedirectToAction("ManagerHome", "Manager");
                    }
                    else if (role == "supervisor")
                    {
                        return RedirectToAction("SupervisorHome", "Supervisor");
                    }
                    else
                    {
                        return View("LoginAccount", model);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("LoginAccount", model);
            }
            return View();
        }
    }
}
