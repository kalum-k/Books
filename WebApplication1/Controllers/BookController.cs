using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task <IEnumerable<BookModel>> GetBooks()
        {
            return await _bookRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            return await _bookRepository.Get(id);
        }
        
        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBook([FromBody] BookModel book)
        {
            var NewBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBook),new {id = NewBook.Id},NewBook) ;
        } 
        
        [HttpPut]
        public async Task<ActionResult<BookModel>> PutBook(int id, [FromBody] BookModel book)
        {
            if(id != book.Id)
            {
                return BadRequest();
            }
            await _bookRepository.Update(book);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<BookModel>> DeleteBook(int id, [FromBody] BookModel book)
        {
            if(id == null)
            {
                return BadRequest();
            }
            await _bookRepository.Delete(id);
            return NoContent();
        }

    }
}
