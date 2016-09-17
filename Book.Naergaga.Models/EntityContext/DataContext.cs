using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.EntityContext
{
    public class DataContext:DbContext
    {
        public DataContext() : base("conn1") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<EBook> EBooks { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<BookTags> BookTags { get; set; }

    }
}
