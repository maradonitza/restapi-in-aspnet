using BookstoreApi.Core.Domain;
using BookstoreApi.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookstoreApi.Persistence
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext()
            : base("name=BookstoreContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfiguration());
        }
    }
}