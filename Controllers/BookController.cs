using Microsoft.AspNetCore.Mvc;
using BooksApi.Models;

using BooksApi.Models;

namespace BooksApi.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase {
        
        DataContext dbContext;
        BooksApi.Services.ILogger logger;
        
        public BookController(DataContext dbContext, BooksApi.Services.ILogger logger){
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooks() {
            this.logger.Info("Testing logger");
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