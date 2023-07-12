using BookStore__Management_system.Models;

namespace BookStore__Management_system.Repository
{
    public interface ISaleRepository
    {
        Task<List<SaleModel>> GetAllSaleAsync();
        Task<SaleModel> GetSaleByIdAsync(int saleId);
    }
}
