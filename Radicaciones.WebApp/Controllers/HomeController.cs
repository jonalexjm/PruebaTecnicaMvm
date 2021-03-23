using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Radicaciones.WebApp.Helpers;
using Radicaciones.WebApp.Models;
using Radicaciones.WebApp.ViewModel;

namespace Radicaciones.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IUserHelper _userHelper;

        public HomeController(ILogger<HomeController> logger
             //                 , IUserHelper userHelper
            )
        {
            _logger = logger;
           // _userHelper = userHelper;
        }

        //public IActionResult Login()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(new LoginViewModel());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
        //        if (result.Succeeded)
        //        {
        //            if (Request.Query.Keys.Contains("ReturnUrl"))
        //            {
        //                return Redirect(Request.Query["ReturnUrl"].First());
        //            }

        //            return RedirectToAction("Index", "Home");
        //        }

        //        ModelState.AddModelError(string.Empty, "Email or password incorrect.");
        //    }

        //    return View(model);
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await _userHelper.LogoutAsync();
        //    return RedirectToAction("Index", "Home");
        //}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}