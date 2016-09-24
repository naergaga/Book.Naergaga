using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.CmdTest
{
    public class DataContextTest
    {
        public void TestContext1()
        {
            DataContext context = new DataContext();
            var category = new Category
            {
                Name = "男主",
            };

            var author = new Author
            {
                Name = "小青蛙",
                Description = "广受欢迎的网络小说作家，《永动机之殇》作者。"
            };

            var tag = new Tag
            {
                Name = "玄幻"
            };

            var book = new EBook
            {
                Author = author,
                Category = category,
                Name = "永动机之殇",
                Description = "玄幻，轻松，搞笑",
                Path = "null",
                PostTime = DateTime.Now
            };

            var book1 = context.EBooks.Add(book);
            context.Categories.Add(new Category
            {
                Name = "女主"
            });
            context.Tags.Add(tag);
            context.SaveChanges();

            var bookTags = new BookTags
            {
                BookId = book1.Id,
                TagId = tag.Id
            };
            context.BookTags.Add(bookTags);
            context.SaveChanges();
        }
    }
}
