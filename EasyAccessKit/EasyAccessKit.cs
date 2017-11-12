﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using System.Reflection;
using EasyAccessKit.CarouselClass;
using System.Linq;
using Newtonsoft.Json;

namespace EasyAccessKit
{
    public static class EasyAccessKit
    {
        //Default is Bootstrap 4 Beta
        private static string bsVersion = "4.0.0b";

        public static void BootstrapVersion(string bootstrapVersion)
        {
            bsVersion = bootstrapVersion;
        }

        #region Skip Menu
        [Produces("text/html")]
        public static IHtmlContent SkipMenu()
        { 
            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            htmlContentBuilder.AppendHtmlLine("<nav role='navigation' style='opacity: 0'>");
            htmlContentBuilder.AppendHtmlLine("<a id='skip-link' style='opacity: 0' href='#ez-main-heading'>Skip to main content.</a>");
            htmlContentBuilder.AppendHtmlLine("</nav>");

            return htmlContentBuilder;
        }

        [Produces("text/html")]
        public static IHtmlContent MainHeading(string content, string htmlClass = "", Dictionary<string, string> attributes = null)
        {
            if (attributes == null)
            {
                attributes = new Dictionary<string, string> { { "", "" } };
            }

            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            //Start h1
            htmlContentBuilder.AppendHtml("<h1 id='ez-main-heading' class='" + htmlClass + "'");

            //Set up attributes
            foreach (KeyValuePair<string, string> attribute in attributes)
            {
                if(!String.IsNullOrEmpty(attribute.Key))
                    htmlContentBuilder.AppendHtml(attribute.Key + "='" + attribute.Value + "'");
            }
            htmlContentBuilder.AppendHtml(">");

            //Content
            htmlContentBuilder.AppendHtmlLine(content);

            //End h1
            htmlContentBuilder.AppendHtmlLine("</h1>");

            return htmlContentBuilder;
        }

        [Produces("text/html")]
        public static IHtmlContent HiddenMainHeading(string content, string htmlClass = "", Dictionary<string, string> attributes = null)
        {
            if (attributes == null)
            {
                attributes = new Dictionary<string, string> { { "","" } };
            }

            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            //Start h1
            htmlContentBuilder.AppendHtml("<h1 id='ez-main-heading' style='visibility: hidden;' class='" + htmlClass + "'");

            //Set up attributes
            foreach(KeyValuePair<string, string> attribute in attributes)
            {
                if (!String.IsNullOrEmpty(attribute.Key))
                    htmlContentBuilder.AppendHtml(attribute.Key + "='" + attribute.Value + "'");
            }
            htmlContentBuilder.AppendHtml(">");

            //Content
            htmlContentBuilder.AppendHtmlLine(content);

            //End h1
            htmlContentBuilder.AppendHtmlLine("</h1>");

            return htmlContentBuilder;
        }
        #endregion

        #region Easy Table

        [Produces("text/html")]
        public static IHtmlContent EasyTable(IEnumerable<object> list, string htmlClass = "")
        {
            HtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();
            
            //Start table
            htmlContentBuilder.AppendHtmlLine("<table class='table " + htmlClass + "'>");

            //Table heading
            htmlContentBuilder.AppendHtmlLine("<tr>");
            foreach(object item in list)
            {
                var PropertyInfos = item.GetType().GetProperties();
                foreach(PropertyInfo info in PropertyInfos)
                {
                    htmlContentBuilder.AppendHtmlLine("<th scope='col'>" + info.Name + "</th>");
                }
            }
            htmlContentBuilder.AppendHtmlLine("</tr>");

            //Content of tables
            foreach (object item in list)
            {
                htmlContentBuilder.AppendHtmlLine("<tr>");

                var PropertyInfos = item.GetType().GetProperties();

                //Gets first column data and adds scope
                PropertyInfo firstInfo = PropertyInfos.FirstOrDefault();
                htmlContentBuilder.AppendHtmlLine("<td scope='row'>" + firstInfo.GetValue(item) + "</td>");

                //Loop through rest of data
                foreach (PropertyInfo info in PropertyInfos.Skip(1))
                {
                    htmlContentBuilder.AppendHtmlLine("<td>" + info.GetValue(item) + "</td>");  
                }

                htmlContentBuilder.AppendHtmlLine("</tr>");
            }
            //End table
            return htmlContentBuilder;
        }
        #endregion

        #region Carousel
        [Produces("text/html")]
        public static IHtmlContent Carousel(List<CarouselItem> items)
        {
            HtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            if (bsVersion == "4.0.0b")
            {
                htmlContentBuilder.AppendHtml(
                    "<div id='ez-carousel' class='carousel slide' data-ride='carousel' data-interval='false'>" +
                    "<ol class='carousel-indicators'>"
                    );

                //Adding tabs at bottom.
                for (int i = 0; i > items.Count; i++)
                {
                    htmlContentBuilder.AppendHtmlLine("<li data-target='#ez-carousel' data-slide-to='" + i.ToString() + "'></li>");
                }

                htmlContentBuilder.AppendHtmlLine("</ol>" +
                    "<div class='carousel-inner'>"
                    );

                //Adding each item
                foreach (CarouselItem item in items)
                {
                    htmlContentBuilder.AppendHtml("<div class='carousel-item'>" +
                        "<img class='d-blockw-100' src='" + item.ImageUrl + "' alt='" + (String.IsNullOrEmpty(item.AltText) ? item.SubHeading : item.AltText) + "'>" +
                        "<h3>" + item.Title + "</h3>" +
                        "<p>" + item.SubHeading + "</p>" +
                        "</div>"
                        );
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
            }
            else if(bsVersion == "3.3.7")
            {

            }
            return htmlContentBuilder;
        }

        #endregion
    }
}
