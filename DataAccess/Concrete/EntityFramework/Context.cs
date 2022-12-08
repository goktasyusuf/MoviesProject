using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb; database =Movies2Db ; Trusted_Connection=true ; integrated security=true");
        }

        
        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
    }
}
