using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.Models
{
    public class Author
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }      
        public string LastName { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}