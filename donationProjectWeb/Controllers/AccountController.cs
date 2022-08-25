using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using donationProjectWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace donationProjectWeb
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(Screennamerecord user)
        {
            using ( var db = new donationprojectdbContext())
            {
                var _result = db.Screennamerecord.Where(s => s.Username == user.Username && s.UserPassword == user.UserPassword);
                if (_result.Any())
                {
                    return Json(new { status = true, message = "Login Successful" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Username or Password" });
                }
                 
            }
            
        }
    }
}