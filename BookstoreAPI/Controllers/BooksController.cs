using AutoMapper;
using BookStore__Management_system.Data;
using BookStore__Management_system.Models;
using BookStore__Management_system.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore__Management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly AuthService authService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public BooksController(IBookRepository bookRepository, AuthService authService, IMapper mapper, ILogger logger)
        {
            _bookRepository = bookRepository;
            this.authService = authService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string searchTerm)
        {
            var books = await _bookRepository.SearchBooksAsync(searchTerm);
            return Ok(books);
        }

        [HttpGet("FindBook/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost("AddBook")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _bookRepository.AddBookAsync(bookModel);
                    return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" }, $"Book Added Successfully.\nYour Book Id Is : {id}");
                }

                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
    }
    [HttpPut("UpdateBook/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok("Book Updated Successfully....");
        }
        [HttpPatch("UpdateBook/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok("Book Updated Successfully....");
        }
        [HttpDelete("DeleteBook/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok("Book Deleted Successfully....");
        }

        //[HttpPost("add-to-cart/{id:int}")]
        //public async Task<IActionResult> AddToCart([FromRoute] int id)
        //{
        //    try
        //    {
               
        //        var book = await _bookRepository.GetBookByIdAsync(id);
        //        if (book == null)
        //        {
        //            return NotFound(); // Return NotFound if the book doesn't exist
        //        }

              

        //        return Ok("Book added to cart successfully.");
        //    }
        //    catch (Exception ex)
        //    {
               
        //        return BadRequest("Error occurred while adding the book to the cart: " + ex.Message);
        //    }
        //}

    }
}