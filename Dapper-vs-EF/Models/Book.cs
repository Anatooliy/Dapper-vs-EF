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

        [DisplayName("Название книги")]
        public string BookName { get; set; }

        [DisplayName("Дата публикации")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BookBirth { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}