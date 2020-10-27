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
                LanguageId = model.LanguageId,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks() 
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Id = book.Id,
                    Category = book.Category,
                    Language = book.Language.Name,
                   
                }).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Id = book.Id,
                    Category = book.Category,
                    Language = book.Language.Name,
                   
            }).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }
    }
}
