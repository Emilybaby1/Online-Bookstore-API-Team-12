using AutoMapper;
using BookStore__Management_system.Data;
using BookStore__Management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore__Management_system.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public SaleRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SaleModel>> GetAllSaleAsync()
        {
            
            var records = await _context.Sales.ToListAsync();
            return _mapper.Map<List<SaleModel>>(records);
        }
        public async Task<SaleModel> GetSaleByIdAsync(int saleId)
        {
            
            var sale = await _context.Sales.FindAsync(saleId);
            return _mapper.Map<SaleModel>(sale);


        } 
    }
    }
