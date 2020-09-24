using Day9projectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day9projectASP.Controllers
{
    public class HomeController : Controller
    {
        UserContext uc = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Welcome to registraation Page";

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
           
                ViewBag.Message = "your registration complete.";
                uc.setuser(user);
            
            
            return View();
        }


        public ActionResult WhoRegister()
        {
            return View(uc.getuser());
        }

      
        public ActionResult Login()
        {
            ViewBag.Message = "login page.";
            return View();
        }

        [HttpPost]
        
        public ActionResult loginform(string txtUsername, string txtPassword)
        {
            ActionResult action = RedirectToAction("Login"); 
            List<User> alluser = uc.getuser();
            foreach (var user in alluser)
            {
                if (user.Username.Equals(txtUsername) && user.Password.Equals(txtPassword))
                {
                    Session["Username"] = user.Username;
                    action = RedirectToAction("Successlogin",new { @txtUsername = Session["Username"] });
                }
            }
            return action;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Successlogin(string txtUsername)
        {
            if (Session["Username"] != null)
            {
                ViewBag.Message = "Welcome Home" + txtUsername;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult AboutFDM()
        {
            if (Session["Username"] != null) { 
            return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult OurOffice()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}