namespace BookAuthorApi.Core.Interfaces
{
    using BookAuthorApi.Core.Entities;
    using BookAuthorApi.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    //All APIs are asynchronous, returning Task or Task<T> to support non-blocking operations. This is particularly useful for I/O-bound operations like database access. All End points are implemented asynchronously.
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<Author> AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int authorId);
    }
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private  readonly BookAuthorDbContext _context;
        public AuthorRepository(BookAuthorDbContext context)
        {
            this._context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;//implicitly filled with the generated AuthorId
        }

        public Task DeleteAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId) => await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == authorId);


        public Task UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }

    public class BookRepository : IBookRepository
    {
        private readonly BookAuthorDbContext _context;
        public BookRepository(BookAuthorDbContext context)
        {
            this._context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;//implicitly filled with the generated BookId
        }
        public Task DeleteBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
        public async Task<Book> GetBookByIdAsync(int bookId) => await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.BookId == bookId);
        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}