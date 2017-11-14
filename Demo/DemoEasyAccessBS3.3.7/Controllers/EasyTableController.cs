using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoEasyAccess.Models;
namespace DemoEasyAccess.Controllers
{
    public class EasyTableController : Controller
    {
        public IActionResult Index()
        {
            List<EasyTableModel> models = new List<EasyTableModel>();

            EasyTableModel model1 = new EasyTableModel();
            model1.EmployeeId = "1";
            model1.EmployeeName = "Dan";
            model1.JobTitle = "Manager";
            models.Add(model1);

            return View(models);
        }
    }
}