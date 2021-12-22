namespace WebApplication1.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookModel>> Get();
        Task<BookModel> Get(int id);
        Task<BookModel> Create(BookModel book);
        Task Update(BookModel book);
        Task Delete(int id);
    }
}
