using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Data.Models;
using BookShop.Data.ViewModels;

namespace BookShop.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            this._context = context;
        }

        // get all books
        public List<Book> GetAll()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }
        
        // get a book by id
        public Book getBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        // add new book
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title =  book.Title,
                Description = book.Description,
                IsRead =  book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : (DateTime?) null,
                Rate =  book.IsRead ? book.Rate.Value : (int ?)null,
                Genre =  book.Genre,
                Author =  book.Author,
                CoverUrl =  book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        
        // update book
        public Book UpdateBook(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : (DateTime?) null;
                _book.Rate = book.IsRead ? book.Rate.Value : (int?) null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }
        
        // delete book
        public void DeleteBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _context.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}