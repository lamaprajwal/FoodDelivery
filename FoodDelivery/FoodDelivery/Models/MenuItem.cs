using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Item { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Foreign key
        public int ResturantId { get; set; }

        // Navigation property
        [ForeignKey("ResturantId")]
        public virtual Restaurant? Resturant { get; set; }

        // Foreign Key
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // Navigation Property
        public virtual Category? Category { get; set; }

    }

}
