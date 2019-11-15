using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dapper_vs_EF.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            Country country1 = new Country { Name = "Франция" };
            Country country2 = new Country { Name = "Австро-Венгрия" };
            Country country3 = new Country { Name = "Украина" };

            Author author1 = new Author { FirstName = "Оноре де", LastName = "Бальзак", Country = country1 };
            Author author2 = new Author { FirstName = "Александр", LastName = "Дюма", Country = country1 };
            Author author3 = new Author { FirstName = "Франц", LastName = "Кафка", Country = country2 };
            Author author4 = new Author { FirstName = "Тарас", LastName = "Шевченко", Country = country3 };            

            Book book1 = new Book
            {
                BookName = "Гобсек",
                BookBirth = DateTime.Now.AddYears(-150),
                Author = author1
            };
            Book book2 = new Book
            {
                BookName = "Тридцатилетняя женщина",
                BookBirth = DateTime.Now.AddYears(-155),
                Author = author1 };
            Book book3 = new Book {
                BookName = "Отец Горио",
                BookBirth = DateTime.Now.AddYears(-140),
                Author = author1
            };
            Book book4 = new Book
            {
                BookName = "Три мушкетёра",
                BookBirth = DateTime.Now.AddYears(-100),
                Author = author2
            };
            Book book5 = new Book
            {
                BookName = "Железная маска",
                BookBirth = DateTime.Now.AddYears(-88),
                Author = author2
            };
            Book book6 = new Book
            {
                BookName = "Превращение",
                BookBirth = DateTime.Now.AddYears(-200),
                Author = author3
            };
            Book book7 = new Book
            {
                BookName = "В исправительной колонии",
                BookBirth = DateTime.Now.AddYears(-201),
                Author = author3
            };
            Book book8 = new Book
            {
                BookName = "Внезапная прогулка",
                BookBirth = DateTime.Now.AddYears(-202),
                Author = author3
            };
            Book book9 = new Book
            {
                BookName = "Приговор",
                BookBirth = DateTime.Now.AddYears(-203),
                Author = author3
            };
            Book book10 = new Book
            {
                BookName = "Кобзарь",
                BookBirth = DateTime.Now.AddYears(-10),
                Author = author4
            };


            context.Authors.AddRange(new List<Author> { author1, author2, author3, author4 });
            context.Books.AddRange(new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10 });

            base.Seed(context);
        }
    }
}