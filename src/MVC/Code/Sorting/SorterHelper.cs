
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Encodings.Web;

namespace Mvc.Code
{
    // sorter helper class. Holds extension methods.
    
    public static class SorterHelper
    {
        // extension method. Returns anchor element (a) that contains the virtual path for sort action.
        // this is where column sort headers are created.
        public static HtmlString Sorter<T>(this IHtmlHelper html, SortedList<T> list, string linkText, string sort, string order, object htmlAttributes = null)
        {
            if (list == null) return null;

            //Microsoft.AspNetCore.Html.HtmlContentBuilder hcb = new Microsoft.AspNetCore.Html.HtmlContentBuilder();
            //IHtmlGenerator g;            
            //AnchorTagHelper aTagHelper = new AnchorTagHelper();

            var tag = new TagBuilder("a");
            tag.InnerHtml.AppendHtml(linkText);

            // set Css class to selected if indeed selected

            if (list.Sort.Equals(sort, StringComparison.OrdinalIgnoreCase))
                tag.AddCssClass("selected-" + list.Order);

            // Onclick: submit back and sort by same column but in reverse order. Uses jQuery.

            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.MergeAttribute("onclick", "$('#sort').val('" + sort + "');$('#order').val('" + list.Order.ReverseOrder() + "');$('form').submit();return false;");

            // set the correct url to anchor tag. 

            var request = html.ViewContext.HttpContext.Request;
            var absoluteUri = string.Concat(
                                    request.Scheme,
                                    "://",
                                    request.Host.ToUriComponent(),
                                    request.PathBase.ToUriComponent(),
                                    request.Path.ToUriComponent(),
                                    request.QueryString.ToUriComponent());

            //string url = urlHelper.RouteUrl(dictionary);
            tag.MergeAttribute("href", absoluteUri);

            var writer = new System.IO.StringWriter();
            tag.WriteTo(writer, HtmlEncoder.Default);
            var s = writer.ToString();
            

            return new HtmlString(s);
        }

        // reverses sort order

        private static string ReverseOrder(this string order)
        {
            return order.ToLower() == "asc" ? "desc" : "asc";
        }
    }
}