using Class03_WebApi_Homework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03_WebApi_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("queryString")]
        public ActionResult<Book> GetByQueryString(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("Index is required.");
                }
                if (index < 0)
                {
                    return BadRequest("Index can only be a positive value");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resource with an index of {index}");
                }
                return Ok(StaticDb.Books[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured");
            }
        }


        [HttpGet("filter")]
        public ActionResult<List<Book>> FilterBooks(string? author, string? title)
        {
            try
            {
                if(string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return BadRequest("Insert at least one query paramater");
                }
                if (!string.IsNullOrEmpty(author))
                {
                    return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower()).ToList());
                }
                if(!string.IsNullOrEmpty(title))
                {
                    return Ok(StaticDb.Books.Where(x => x.Title.ToLower() == title.ToLower()).ToList());
                }
                if (StaticDb.Books.Count == 0)
                {
                    return NotFound($"Book with name and/or author was not found.");
                }
                return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occure.");
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Please enter author");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Please enter title");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured.");
            }
        }
    }
}
