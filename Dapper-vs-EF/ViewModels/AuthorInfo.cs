using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.ViewModels
{
    public class AuthorInfo
    {
        public string FullAuthorName{ get; set; }
        public string Country { get; set; }
        public int BookCount { get; set; } = 0;
    }
}