using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Common
{
    public class WebDownloader
    {
        static string p = "http://www.zei8.co";
        static Uri uri = new Uri("http://www.zei8.co/txt");
        static string path1 = "C:\\ebook";

        public void Start()
        {
            WebClient client = new WebClient();
            string str = GetHtml(uri);
            BookBuilder builder = new BookBuilder();
            var books = builder.GetBooks(str);
        }

        public static string GetHtml(Uri p1)
        {
            WebClient client = new WebClient();
            return client.DownloadString(p1);
        }

        
        public static string GetChildHtml(string url)
        {
            WebClient client = new WebClient();
            Uri p1 = new Uri(p + url);
            return client.DownloadString(p1);
        }

        public static string Down(string url,string name)
        {
            WebClient client = new WebClient();
            string p1 = p + url;
            if(!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            string path = path1 +"\\"+ name;
            HttpDownloadFile(p1, path);
            return path;
        }

        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);

            byte[] bArr = new byte[1024*1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

    }
}
