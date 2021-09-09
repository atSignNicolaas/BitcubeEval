//Unused controller as well its views
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Trainingfacility_Bitcube.Models;

namespace Trainingfacility_Bitcube.Controllers
{
    public class AccountController : Controller 
    {
        private readonly MvcDataContext _context;

        public AccountController(MvcDataContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username", "Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                var dataobject = await _context.Account.Where(a => a.Username.Equals(account.Username) 
                && a.Password.Equals(account.Password)).FirstOrDefaultAsync();
                if (dataobject != null)
                {
                    HttpContext.Session.SetString("UserId", account.Id.ToString());
                    HttpContext.Session.SetString("Username", account.Username.ToString());
                    return RedirectToAction("Dashboard");
                }
            }
            return View(account);
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserId") != null)
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