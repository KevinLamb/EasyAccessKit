using EasyAccessKit.CarouselClass;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyAccessKit
{
    public class Bs3 : GlobalFeatures
    {
        #region Carousel

        [Produces("text/html")]
        public static IHtmlContent Carousel(List<CarouselItem> items)
        {
            HtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();
            
            htmlContentBuilder.AppendHtml(
                "<div id='ez-carousel' class='carousel slide' data-interval='false' data-ride='carousel'>" +
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

            htmlContentBuilder.AppendHtmlLine("</ol>");

            //Wrapper for slides
            htmlContentBuilder.AppendHtml(
                "<div class='carousel-inner' role='listbox'>"
            );

            //Adding each item
            foreach (CarouselItem item in items)
            {
                if (item == items.First())
                {
                    htmlContentBuilder.AppendHtml(
                        "<div class='item active'>" +
                        "<img src = '" + item.ImageUrl + "' alt = '" + item.AltText + "' >" +
                        "<div class='carousel-caption'>" +
                        item.Title +
                        "</div>" +
                        "</div>"
                    );
                }
                else
                {
                    htmlContentBuilder.AppendHtml(
                        "<div class='item'>" +
                        "<img src = '" + item.ImageUrl + "' alt = '" + item.AltText + "' >" +
                        "<div class='carousel-caption'>" +
                        item.Title +
                        "</div>" +
                        "</div>"
                    );
                }
            }

            htmlContentBuilder.AppendHtml(
                "</div>" +
                "<a class='left carousel-control' href='#ez-carousel' role='button' data-slide='prev'>" +
                "<span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>" +
                "<span class='sr-only'>Previous</span>" +
                "</a>" +
                "<a class='right carousel-control' href='#ez-carousel' role='button' data-slide='next'>" +
                "<span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>" +
                "<span class='sr-only'>Next</span>" +
                "</a>" +
                "</div>"
            );

            
            return htmlContentBuilder;
        }

        #endregion
    }
}
