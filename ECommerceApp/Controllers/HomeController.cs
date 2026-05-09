using System;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("BOOM! The homepage just crashed!");
        }

        // Notice we removed the word "Csharp" here!
        [TypeFilter(typeof(ECommerceApp.Filters.AuthFilter))]
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}