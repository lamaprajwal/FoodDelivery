using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        public int ResturantId {  get; set; }
    }
}
