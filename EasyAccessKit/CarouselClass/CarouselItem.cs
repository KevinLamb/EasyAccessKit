using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAccessKit.CarouselClass
{
    public class CarouselItem
    {
        public string ImageUrl{ get; set; }

        public string Title { get; set; }

        public string SubHeading { get; set; }

        public string AltText { get; set; }

        public CarouselItem()
        {
            ImageUrl = "";
            Title = "";
            SubHeading = "";
            AltText = "";
        }

        public CarouselItem(string imageURL, string title, string subHeading)
        {
            ImageUrl = imageURL;
            Title = title;
            SubHeading = subHeading;
            AltText = "";
        }

        public CarouselItem(string imageURL, string title, string subHeading, string altText)
        {
            ImageUrl = imageURL;
            Title = title;
            SubHeading = subHeading;
            AltText = altText;
        }
    }
}
