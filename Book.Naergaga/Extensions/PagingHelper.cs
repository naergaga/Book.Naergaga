using Book.Naergaga.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Book.Naergaga.Extensions
{
    public static class PagingHelper
    {
        private static int linkCount = 5;

        public static MvcHtmlString Paging(this HtmlHelper helper, PageOption option, string action, string controller, RouteValueDictionary coll=null)
        {
            if (coll == null) coll = new RouteValueDictionary();
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            return new MvcHtmlString(string.Format(
                "<nav class='page navigation'><ul class='pagination'>" +
                "{0}{1}{2}" +
                "</ul></nav>",
                buildLink(urlHelper, option, action, controller, -1, "&laquo",coll),
                buildSomeLinks(urlHelper, option, action, controller,coll),
                buildLink(urlHelper, option, action, controller, 1, "&raquo",coll)
                ));
        }

        private static object buildSomeLinks(UrlHelper urlHelper, PageOption option, string action, string controller, RouteValueDictionary coll)
        {
            int cut = linkCount / 2;
            bool ji = linkCount % 2 == 1;

            var sb = new StringBuilder();
            for (int i = ji ? -cut : -cut + 1; i <= (ji ? cut : cut + 1); i++)
            {
                if (pageValid(option.CurrentPage + i, option.PageCount))
                {
                    sb.Append(buildLink(urlHelper, option, action, controller, i, (option.CurrentPage + i).ToString(),coll));
                }
            }
            return sb.ToString();
        }

        private static bool pageValid(int i, int count)
        {
            return i >= 1 && i <= count;
        }

        private static string buildLink(UrlHelper urlHelper, PageOption option, string action, string controller, int pos, string text, RouteValueDictionary coll)
        {
            var tmpColl = new RouteValueDictionary(coll);

            int current = option.CurrentPage + pos;
            tmpColl.Add("currentPage", current);
            bool disabled = false;
            if (!pageValid(current, option.PageCount))
                disabled = true;
            return string.Format("<li{1}><a href='{0}'>{2}</a><li>",
                //urlHelper.Action(action, controller, new { currentPage = current }),
                urlHelper.Action(action, controller,tmpColl),
                pos == 0 ? " class='active'" : disabled ? " class='disabled'" : string.Empty, text);
        }
    }
}