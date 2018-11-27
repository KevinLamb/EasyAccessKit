using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyAccessKit
{
    public class GlobalFeatures
    {

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

        #region Figure

        [Produces("text/html")]
        public static IHtmlContent Figure(string imageSrc, string imageAlt, string description)
        {
            HtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            //Start figure
            htmlContentBuilder.AppendHtmlLine("<figure role='group'>");

            //Add image
            htmlContentBuilder.AppendHtmlLine("<img src='" + imageSrc + "' alt='" + imageAlt + "'>");

            //Adding caption
            htmlContentBuilder.AppendHtml("<figcaption>"
                + description
                + "</figcaption>"
                );

           //End figure
            htmlContentBuilder.AppendHtmlLine("</figure>");

            return htmlContentBuilder;
        }

        #endregion

    }
}
