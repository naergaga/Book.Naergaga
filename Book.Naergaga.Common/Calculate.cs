using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Common
{
    public class Calculate
    {
        const long tb = 1099511627776; //1024 * 1024 * 1024*1024 定义TB的计算常量  
        const int gb = 1073741824; //1024 * 1024 * 1024 定义GB的计算常量  
        const int mb = 1048576; //1024 * 1024定义MB的计算常量  
        const int kb = 1024; //定义TB的计算常量  

        public static string GetSize(int size)
        {
            var flow = (double)size;

            if (flow / tb >= 1)
            {
                return (Math.Round(flow / tb, 2)) + " TB";
            }
            if (flow / gb >= 1)
            {
                return (Math.Round(flow / gb, 2)) + " GB";
            }
            if (flow / mb >= 1)
            {
                return (Math.Round(flow / mb, 2)) + " MB";
            }
            if (flow / kb >= 1)
            {
                return (Math.Round(flow / kb, 2)) + " KB";
            }
            return Math.Round(flow, 2) + " B";
        }

    }
}
