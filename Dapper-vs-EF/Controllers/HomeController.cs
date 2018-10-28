using Dapper;
using Dapper_vs_EF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dapper_vs_EF.Controllers
{
    public class HomeController : Controller
    {
        private BookContext db = new BookContext();
        private SqlConnection dapperConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookContext"].ToString());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dapper()
        {
            string sql = @"select concat(AuthorName, ' ', LastName) as 'Author', Country,  count(Books.Id) as 'BookCount'
                            from Authors
	                            join Books
	                            on Authors.Id = Books.AuthorId                           
                            group by concat(AuthorName, ' ', LastName), Country
                            order by 1";
            ViewBag.Authors = dapperConn.QueryMultiple(sql).Read().ToList();            
            return View();
        }

        public ActionResult SearchBookDapper(string name)
        {
            string sql = @"select BookName, BookBirth
                            from Books
	                            join Authors
	                            on Authors.Id = Books.AuthorId
                            where Authors.LastName like N'%" + name + "%'";

            var allbooks = dapperConn.Query<Book>(sql).ToList();            

            if (allbooks.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allbooks);
        }

        public ActionResult EntityFramework()
        {
            return View(db.Authors.ToList());
        }
    }
}