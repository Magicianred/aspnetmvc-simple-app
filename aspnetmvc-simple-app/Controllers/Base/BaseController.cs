using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Markdig;

namespace aspnetmvc_simple_app.Controllers
{
        public class BaseController : Controller
        {
                /// <summary>
                /// Convert Markdown in Html
                /// </summary>
                /// <param name="md">text in markdown</param>
                /// <returns>text in html</returns>
                protected string MarkdownToHtml(string md) {
                        string html = Markdown.ToHtml(md);
                        return html;
                }

                /// <summary>
                /// Strip Html except for some tags
                /// <h1><h2><h3><ol><ul><li><p><i><b><a><em><strong>
                /// </summary>
                /// <param name="html">html to strip</param>
                /// <returns>html with only allowed tags</returns>
                protected string StripHtml(string html) {
                        var allowedOnlyThisTags = new Regex(@"(</?[^(h1|h2|h3|ol|ul|li|p|i|b|a|em|strong)]/?>)");
                        return allowedOnlyThisTags.Replace(html, "");
                }
        }
}