using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.Models
{
    public class Book
    {
        public int Id { get; set; }        
        public string BookName { get; set; }
        
        [DataType(DataType.Date)]        
        public DateTime? BookBirth { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}