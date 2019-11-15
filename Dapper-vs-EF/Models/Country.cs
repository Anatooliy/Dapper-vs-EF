using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public Country()
        {
            Authors = new List<Author>();
        }
    }
}