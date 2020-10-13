using BookStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks() 
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="Design API", Author="Jr", Description="This book is about Designing API from scratch to advanced", Category="API", Language="English", Pages=317},
                new BookModel(){Id=2, Title="Design & Architecture", Author="Jr",Description="This book is about Designing & Architecture from scratch to advanced", Category="Architecture", Language="Spanish", Pages=1017},
                new BookModel(){Id=3, Title="OOP", Author="Swift",Description="This book is about Designing OOP from scratch to advanced", Category="OOP", Language="Bangla", Pages=834},
            };
        }
    }
}
