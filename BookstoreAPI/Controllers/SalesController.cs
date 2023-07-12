using BookStore__Management_system.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore__Management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _saleRepository.GetAllSaleAsync();
            return Ok(sales);
        }
        [HttpGet("FindSale/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);
            if (sale == null)
                return NotFound();
            return Ok(sale);
        }
    }
}
