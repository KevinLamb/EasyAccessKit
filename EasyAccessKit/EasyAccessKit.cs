using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;

namespace EasyAccessKit
{
    public static class EasyAccessKit
    {
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
                attributes.Add("", "");
            }

            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            //Start h1
            htmlContentBuilder.AppendHtml("<h1 id='ez-main-heading' class='" + htmlClass + "'");
            foreach (KeyValuePair<string, string> attribute in attributes)
            {
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
                attributes.Add("", "");
            }

            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            //Start h1
            htmlContentBuilder.AppendHtml("<h1 id='ez-main-heading' style='visibility: hidden;' class='" + htmlClass + "'");
            foreach(KeyValuePair<string, string> attribute in attributes)
            {
                htmlContentBuilder.AppendHtml(attribute.Key + "='" + attribute.Value + "'");
            }
            htmlContentBuilder.AppendHtml(">");

            //Content
            htmlContentBuilder.AppendHtmlLine(content);

            //End h1
            htmlContentBuilder.AppendHtmlLine("</h1>");

            return htmlContentBuilder;
        }
    }
}
