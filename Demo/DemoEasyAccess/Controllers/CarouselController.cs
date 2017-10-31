using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAccessKit.CarouselClass;

namespace DemoEasyAccess.Carousel
{
    public class CarouselController : Controller
    {
        public IActionResult Index()
        {
            List<CarouselItem> items = new List<CarouselItem>();

            CarouselItem item1 = new CarouselItem();
            item1.ImageUrl = "#";
            item1.Title = "Image 1";
            item1.SubHeading = "This is the first image";
            item1.AltText = "There is currently no image loaded but this is the alt text to image 1.";

            CarouselItem item2 = new CarouselItem("#", "Image 2", "This is image 2", "There is no actual image but this is the image 1 alt text");

            items.Add(item1);
            items.Add(item2);

            return View(items);
        }
    }
}