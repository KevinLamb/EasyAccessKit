﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoEasyAccess.Controllers
{
    public class FigureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}