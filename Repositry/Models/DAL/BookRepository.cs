using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositry.Models.DAL
{
    public class BookRepository : IBookRepository
    {

        private DataContext _context;

        public BookRepository(DataContext context)
        {
            this._context = context;
        }
        public void DeleteBook(int bookID)
        {

            Book book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Book GetBookByID(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks() 
        {
            return _context.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }
    }
}