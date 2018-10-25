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

        [DisplayName("Имя Автора")]
        public string AuthorName { get; set; }

        [DisplayName("Фамилия Автора")]
        public string LastName { get; set; }

        [DisplayName("Страна")]
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
}