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
            Author author1 = new Author { AuthorName = "Оноре де", LastName = "Бальзак", Country = "Франция"};
            Author author2 = new Author { AuthorName = "Александр", LastName = "Дюма", Country = "Франция" };
            Author author3 = new Author { AuthorName = "Франц", LastName = "Кафка", Country = "Австро-Венгрия" };
            Author author4 = new Author { AuthorName = "Тарас", LastName = "Шевченко", Country = "Украина" };

            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.Authors.Add(author3);
            context.Authors.Add(author4);

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

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);
            context.Books.Add(book8);
            context.Books.Add(book9);
            context.Books.Add(book10);

            context.Books.AddRange(new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10 });

            base.Seed(context);
        }
    }
}