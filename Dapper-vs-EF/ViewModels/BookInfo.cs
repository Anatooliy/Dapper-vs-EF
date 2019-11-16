using System;
using System.ComponentModel.DataAnnotations;

namespace Dapper_vs_EF.ViewModels
{
    public class BookInfo
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BookBirth { get; set; }        
    }
}