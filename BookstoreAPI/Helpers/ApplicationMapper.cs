using AutoMapper;
using BookStore__Management_system.Data;
using BookStore__Management_system.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore__Management_system.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();

            CreateMap<Sales, SaleModel>().ReverseMap();
        }
    }
}
