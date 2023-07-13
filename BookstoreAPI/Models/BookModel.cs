using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore__Management_system.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
        public string? Genre { get; set; }
        public float Price { get; set; }
    }
}