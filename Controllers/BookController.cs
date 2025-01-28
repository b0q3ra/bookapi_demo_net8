using Microsoft.AspNetCore.Mvc;
using BooksApi.Models;

using BooksApi.Models;

namespace BooksApi.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase {
        
        DataContext dbContext;
        
        public BookController(DataContext dbContext){
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooks() {
            return dbContext.books;
        }


        [HttpPost]
        public async Task<IActionResult> postBook([FromBody] BookModel book) {

            try{
                dbContext.books.AddAsync(book);
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }catch(Exception e){
                return BadRequest();
            }
        }




    }
}