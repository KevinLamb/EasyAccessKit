using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoEasyAccessBS3._3._7.Controllers
{
    public class SkipMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}