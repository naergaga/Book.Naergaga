using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Extensions
{
    public static class CommonHelper
    {

        private static string[] sizeStr = new string[] {"B","K","M","G" };

        public static MvcHtmlString FormatLength(this HtmlHelper helper,long length)
        {
            int tmp= (int)length;
            int tmp1 = tmp;
            int count=0;
            do
            {
                if (tmp >= 1024) count++;
                else break;
                tmp = tmp / 1024;
            } while (true);

            var tmp3 = Math.Pow(1024, count);
            var tmp2 = tmp1%tmp3/ tmp3;
            int tmp4 = tmp1 / (int)tmp3;

            return new MvcHtmlString(string.Format("{0}{2}{1}",tmp4,sizeStr[count],count==0?string.Empty:"."+(int)tmp2*100));
        }

    }
}