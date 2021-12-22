using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<BookModel> Create(BookModel book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Book.FindAsync(id);
            _context.Book.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<BookModel>> Get()
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<BookModel> Get(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task Update(BookModel book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
