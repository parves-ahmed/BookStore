using BookStoreApplication.Data;
using BookStoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStoreApplication.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                Pages = model.Pages.HasValue ? model.Pages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks() 
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if(allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Pages = book.Pages,
                        Id = book.Id,
                        Category = book.Category,
                        Language = book.Language
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Id = book.Id,
                    Category = book.Category,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
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
