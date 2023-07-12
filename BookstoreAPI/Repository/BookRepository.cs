using AutoMapper;
using BookStore__Management_system.Data;
using BookStore__Management_system.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore__Management_system.Repository
{ 
  public class BookRepository : IBookRepository
{
    private readonly BookStoreContext _context;
    private readonly IMapper _mapper;

    public BookRepository(BookStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<BookModel>> GetAllBookAsync()
    {
        //var records =await _context.Books.Select(x => new BookModel() {
        //    Id = x.Id,
        //    Name = x.Name,
        //    Description = x.Description
        //}).ToListAsync();

        //return records;
        var records = await _context.Books.ToListAsync();
        return _mapper.Map<List<BookModel>>(records);
    }
    public async Task<BookModel> GetBookByIdAsync(int bookId)
    {
        //var records = await _context.Books.Where(x => x.Id == bookId ).Select(x=>new BookModel()
        //{
        //    Id = x.Id,
        //    Name = x.Name,
        //    Description = x.Description
        //}).FirstOrDefaultAsync();                                                                                                                         

        //return records;

        var book = await _context.Books.FindAsync(bookId);
        return _mapper.Map<BookModel>(book);


    }
    public async Task<int> AddBookAsync(BookModel bookModel)
    {
        var book = new Books()
        {
            Id = bookModel.Id,
            BookTitle = bookModel.BookTitle,
            BookAuthor = bookModel.BookAuthor,
            Genre= bookModel.Genre,
            Price= bookModel.Price
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book.Id;
    }
    public async Task UpdateBookAsync(int bookId, BookModel bookModel)
    {
        //var book = await _context.Books.FindAsync(bookId);
        //if (book != null)
        //{
        //    book.Name = bookModel.Name;
        //    book.Description = bookModel.Description;

        //    await _context.SaveChangesAsync();
        //}
        var book = new Books()
        {
            Id = bookModel.Id,
            BookTitle = bookModel.BookTitle,
            BookAuthor = bookModel.BookAuthor,
            Genre = bookModel.Genre,
            Price = bookModel.Price
        };

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        //return book.Id;
    }
    public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book != null)
        {
            bookModel.ApplyTo(book);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteBookAsync(int bookId)
    {
        //var book = await _context.Books.FindAsync(bookId);
        var book = new Books() { Id = bookId };
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
        public async Task<List<BookModel>> SearchBooksAsync(string searchTerm)
        {
            // Your logic to search and retrieve books
            List<BookModel> bookModels = new List<BookModel>();

            if (searchTerm == "fiction")
            {
                bookModels.Add(new BookModel { BookTitle = "The Great Gatsby", BookAuthor = "F. Scott Fitzgerald" });
                bookModels.Add(new BookModel { BookTitle = "To Kill a Mockingbird", BookAuthor = "Harper Lee" });
            }
            else if (searchTerm == "science")
            {
                bookModels.Add(new BookModel { BookTitle = "A Brief History of Time", BookAuthor = "Stephen Hawking" });
                bookModels.Add(new BookModel { BookTitle = "The Elegant Universe", BookAuthor = "Brian Greene" });
            }

            return bookModels;
        }
    }
}