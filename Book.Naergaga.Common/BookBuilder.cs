using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.Entity.Temp;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Common
{
    public class BookBuilder
    {

        public BookBuilder()
        {
        }

        public List<TmpBook> GetBooks(string html)
        {
            List<string> places = ParseBookAddress(html);
            List<TmpBook> maps = ParseBookEntity(places);
            return maps;
        }

        private List<TmpBook> ParseBookEntity(List<string> places)
        {
            var doc = new HtmlDocument();
            List<TmpBook> map = new List<TmpBook>();
            foreach (var item in places)
            {
                var book = new TmpBook();
                var html = WebDownloader.GetChildHtml(item);
                doc.LoadHtml(html);
                var node = doc.DocumentNode.SelectSingleNode("//div[@class='viewbox']");
                string name = node.SelectSingleNode("//div[@class='title']/h2").InnerText;
                book.Name = name.Substring(name.IndexOf("《")+1, name.IndexOf("》") - 1);
                book.AuthorName=node.SelectSingleNode("//div[@class='infolist']/span[7]").InnerText;
                book.Description = node.SelectSingleNode("//div[@class='content'][1]").InnerText;
                book.Url = item;
                string url = node.SelectSingleNode("//div[@class='content'][2]//a").Attributes["href"].Value;
                string path = WebDownloader.Down(url,book.Name);
                map.Add(book);
            }
            return map;
        }

        private List<string> ParseBookAddress(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='xsnew']/dl/dd/ul/li/a[2]");

            var list = new List<string>();

            foreach (var item in nodes)
            {
                list.Add(item.Attributes["href"].Value);
            }

            return list;
        }
    }
}
