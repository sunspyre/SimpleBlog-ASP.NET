using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
                
            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if (!ModelState.IsValid)
            return View(form);

            if(form.Username != "rainbow dash")
            {
                ModelState.AddModelError("UserName", "Username or pass isn't valid");
                return View(form);
            }

            return Content("This form is valid");
        }
    }
}