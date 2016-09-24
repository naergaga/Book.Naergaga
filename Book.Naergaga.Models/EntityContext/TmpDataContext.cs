using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.Entity.Temp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.EntityContext
{
    public class TmpDataContext:DbContext
    {
        public TmpDataContext() : base("conn2") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(new MyInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TmpBook> TmpBook { get; set; }
    }

    public class MyInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.Database.ExecuteSqlCommand("create unique index ix_tmpbook_url on TmpBook (Url)");
        }
    }
}
