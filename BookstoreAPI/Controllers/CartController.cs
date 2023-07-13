using BookStore__Management_system.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookStore__Management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly BookStoreContext _db;
        [HttpPost("add-to-cart/{id:int}")]
        public async Task<ActionResult> AddToCart(int id, int quantity)
        {
            try
            {
                // Add a book to the shopping cart
                var book = await _db.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }


                //Checks if a book already exists in cart
                var existingCartItem = await _db.CartItems.SingleOrDefaultAsync(c => c.CartId == id && c.BookId == id);

                if (existingCartItem != null)
                {
                    //If book already exists update quantity
                    existingCartItem.Quantity += quantity;

                    await _db.SaveChangesAsync();
                    return Ok($"Quantity of Book-ID {id}, Title -{book.BookTitle} has been updated to {existingCartItem.Quantity} in your cart");
                }
                else
                {
                    var cartItem = new CartItem
                    {

                        CartId = id,
                        BookId = id,
                        Quantity = quantity,

                    };

                    // Save the cart item to the database
                    _db.CartItems.Add(cartItem);
                    await _db.SaveChangesAsync();
                    return Ok($"Book-ID {id} Title-{book.BookTitle} (Quantity: {quantity}) has been added to cart");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to add the book with ID: {id} to the cart. Please try again later.");
            }
        }
    }
}







