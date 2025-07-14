using LibrarySystem.Api.Models;
using LibrarySystem.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Api.Services
{
    public class LibraryService
    {
        private readonly AppDbContext _context;
        public LibraryService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task BorrowBook(string userLibraryNumber, string bookReferenceNumber)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserLibraryNumber == userLibraryNumber);
            Book? book = await _context.Books
                .FirstOrDefaultAsync(b => b.LibraryReferenceNumber == bookReferenceNumber);

            if (user == null)
            { 
                throw new InvalidOperationException("User not found."); 
            }
            if (book == null)
            { 
                throw new InvalidOperationException("Book not found."); 
            }
            if (user.NumberOfBooksBorrowed >= 3)
            {
                throw new InvalidOperationException("User has reached the borrowing limit.");
            }
            if (book.State != Book.BookState.Available)
            { 
                throw new InvalidOperationException("Book is currently not available."); 
            }

            book.SetSate(Book.BookState.CheckedOut);
            user.NumberOfBooksBorrowed++;

            await _context.SaveChangesAsync();
        }

        public async Task ReturnBook(string userLibraryNumber, string bookReferenceNumber)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserLibraryNumber == userLibraryNumber);
            Book? book = await _context.Books
                .FirstOrDefaultAsync(b => b.LibraryReferenceNumber == bookReferenceNumber);

            if (user == null || book == null)
            { 
                throw new InvalidOperationException("User or Book not found."); 
            }

            book.SetSate(Book.BookState.Available);
            user.NumberOfBooksBorrowed--;

            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
