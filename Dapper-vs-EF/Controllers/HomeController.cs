using Dapper;
using Dapper_vs_EF.Models;
using Dapper_vs_EF.ViewModels;
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
            db.Database.Initialize(false);

            ViewBag.ORMName = "Dapper";
            List<AuthorInfo> autors = null;

            string sql = @"select concat(a.FirstName, ' ', a.LastName) as 'FullAuthorName', c.Name as Country, count(b.Id) as 'BookCount'
                            from Authors a
	                            join Books b
	                                on a.Id = b.AuthorId
                                join Countries c
                                    on c.Id = a.CountryId
                            group by concat(a.FirstName, ' ', a.LastName), c.Name";
                       
            autors = dapperConn.Query<AuthorInfo>(sql).OrderBy(a => a.FullAuthorName).ToList();              

            return View("AuthorsInfo", autors);
        }

        [HttpPost]
        public ActionResult SearchBookDapper(string searchParam)
        {
            if (string.IsNullOrEmpty(searchParam))
            {
                return null;
            }

            string sql = @"select BookName, BookBirth
                            from Books
	                            join Authors
	                                on Authors.Id = Books.AuthorId
                            where FirstName like N'%@Name%' or LastName like N'%@Name%'";

            var allBooks = dapperConn.Query<Book>(sql, new { Name = searchParam.Trim() }).ToList();

            return PartialView("SearchedBook", allBooks);
        }

        public ActionResult EntityFramework()
        {
            ViewBag.ORMName = "EntityFramework";

            var autors = db.Authors.Select(s => new AuthorInfo {
                FullAuthorName = s.FirstName + " " + s.LastName,
                Country = s.Country.Name,
                BookCount = s.Books.Count()
            })
            .OrderBy(a => a.FullAuthorName)
            .ToList();

            return View("AuthorsInfo", autors);
        }

        [HttpPost]
        public ActionResult SearchBookEntityFramework(string searchParam)
        {
            searchParam = searchParam.Trim().ToLower();

            var allbooks = db.Books
                .Where(b => b.Author.FirstName.ToLower().Contains(searchParam) 
                    || b.Author.LastName.ToLower().Contains(searchParam)
                )
                .ToList();

            return PartialView("SearchedBook", allbooks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                dapperConn.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}