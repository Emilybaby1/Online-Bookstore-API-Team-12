using BookStore__Management_system.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore__Management_system.Models
{
    public class CartItemModel
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        [ForeignKey(nameof(Books.Id))]
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public float price { get; set; }

        public float subtotal { get; set; }
    }
}
