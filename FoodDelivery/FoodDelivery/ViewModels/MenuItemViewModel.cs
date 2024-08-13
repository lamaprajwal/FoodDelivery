using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.ViewModels
{
    public class MenuItemViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Item { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]

        public int ResturantId {  get; set; }

        [Required]

        public int CategoryId { get; set; }
    }
}
