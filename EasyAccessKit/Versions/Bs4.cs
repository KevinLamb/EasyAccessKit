using EasyAccessKit.CarouselClass;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyAccessKit
{
    public class Bs4 : GlobalFeatures
    {
        #region Carousel

        [Produces("text/html")]
        public static IHtmlContent Carousel(List<CarouselItem> items)
        {
            HtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();
            
            htmlContentBuilder.AppendHtml(
                "<div id='ez-carousel' class='carousel slide' data-ride='carousel' data-interval='false'>" +
                "<ol class='carousel-indicators'>"
                );

            //Adding tabs at bottom.
            for (int i = 0; i > items.Count; i++)
            {
                if (i == 0)
                {
                    htmlContentBuilder.AppendHtmlLine("<li data-target='#ez-carousel' data-slide-to='" + i.ToString() + "' class='active'></li>");
                }
                else
                {
                    htmlContentBuilder.AppendHtmlLine("<li data-target='#ez-carousel' data-slide-to='" + i.ToString() + "'></li>");
                }
            }

            htmlContentBuilder.AppendHtmlLine("</ol>" +
                "<div class='carousel-inner'>"
                );

            //Adding each item
            foreach (CarouselItem item in items)
            {
                if (item == items.First())
                {
                    htmlContentBuilder.AppendHtml("<div class='carousel-item active'>" +
                        "<img class='d-blockw-100' src='" + item.ImageUrl + "' alt='" + (String.IsNullOrEmpty(item.AltText) ? item.SubHeading : item.AltText) + "'>" +
                        "<h3>" + item.Title + "</h3>" +
                        "<p>" + item.SubHeading + "</p>" +
                        "</div>"
                        );
                }
                else
                {
                    htmlContentBuilder.AppendHtml("<div class='carousel-item'>" +
                        "<img class='d-blockw-100' src='" + item.ImageUrl + "' alt='" + (String.IsNullOrEmpty(item.AltText) ? item.SubHeading : item.AltText) + "'>" +
                        "<h3>" + item.Title + "</h3>" +
                        "<p>" + item.SubHeading + "</p>" +
                        "</div>"
                        );
                }
            }
            htmlContentBuilder.AppendHtmlLine("</div>");

            htmlContentBuilder.AppendHtml("<a class='carousel-control-prev' href='#ez-carousel' role='button' data-slide='prev'>" +
                "<span class='carousel-control-prev-icon' aria-hidden='true'></span>" +
                "<span class='sr-only'>Previous</span>" +
                "</a>" +
                "<a class='carousel-control-next' href='#ez-carousel' role='button' data-slide='next'>" +
                "<span class='carousel-control-next-icon' aria-hidden='true'></span>" +
                "<span class='sr-only'>Next</span>" +
                "</a>" +
                "</div>"
            );

            return htmlContentBuilder;
        }

        #endregion
    }
}
