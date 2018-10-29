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

        [HttpPost]
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
            ViewBag.Authors = from b in db.Books
                        join a in db.Authors
                        on b.AuthorId equals a.Id
                        group new { b, a } by new { a.AuthorName, a.LastName, a.Country } into g
                        select new
                        {
                            Name = g.Key.AuthorName + " " + g.Key.LastName,                           
                            Country = g.Key.Country,
                            BookCount = g.Select(x => x.b.AuthorId).Count()
                        };         
            
            return View();
        }


        [HttpPost]
        public ActionResult SearchBookEF(string name)
        {
            ViewBag.Authors = (from b in db.Books
                            join a in db.Authors
                            on b.AuthorId equals a.Id
                            where a.LastName.Contains(name)
                            select new
                            {
                                b.BookName,
                                b.BookBirth,
                               
                            }).ToList();

            return PartialView();
        }
    }
}