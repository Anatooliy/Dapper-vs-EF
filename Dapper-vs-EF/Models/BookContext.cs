using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.Models
{
    public class BookContext : DbContext
    {      
        public BookContext() : base("BookContext")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
    }
}