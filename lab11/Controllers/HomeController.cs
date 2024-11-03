using CalcService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalcService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
