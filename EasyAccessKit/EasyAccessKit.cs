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
        public static IHtmlContent MainHeading(string content)
        {
            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            htmlContentBuilder.AppendHtmlLine("<h1 id='ez-main-heading'>");
            htmlContentBuilder.AppendHtmlLine(content);
            htmlContentBuilder.AppendHtmlLine("</h1>");

            return htmlContentBuilder;
        }

        [Produces("text/html")]
        public static IHtmlContent HiddenMainHeading(string content)
        {
            IHtmlContentBuilder htmlContentBuilder = new HtmlContentBuilder();

            htmlContentBuilder.AppendHtmlLine("<h1 id='ez-main-heading' style='visibility: hidden;'>");
            htmlContentBuilder.AppendHtmlLine(content);
            htmlContentBuilder.AppendHtmlLine("</h1>");

            return htmlContentBuilder;
        }
    }
}
