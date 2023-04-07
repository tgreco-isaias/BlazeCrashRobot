using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeRobot.Extensions.HtmlAgilityPack
{
    public static class HtmlAgilityPackExt
    {
        public static HtmlDocument ToHtmlDocument(this string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc;
        }

        /// <summary>
        /// Transforma HtmlNode em HtmlDocument
        /// </summary>
        public static HtmlDocument ToHtmlDocument(this HtmlNode node)
        {
            return node.OuterHtml.ToHtmlDocument();
        }

        public static IEnumerable<HtmlNode> GetElementsByName(this HtmlDocument doc, string name)
        {
            return doc.DocumentNode.SelectNodes($"//*[@name='{name}']");
        }

        public static IEnumerable<HtmlNode> GetElementsByAttributeValue(this HtmlDocument doc, string attributeName, string value)
        {
            return doc.DocumentNode.SelectNodes($"//*[contains(@{attributeName},'{value}')]");
        }

        public static IEnumerable<HtmlNode> GetElementsByAttributeValue(this HtmlNode node, string attributeName, string value)
        {
            return node.SelectNodes($"//*[contains(@{attributeName},'{value}')]");
        }

        public static IEnumerable<HtmlNode> GetElementsByAttribute(this HtmlNode node, string attributeName)
        {
            return node.SelectNodes($"//*[@{attributeName}]");
        }
    }
}
