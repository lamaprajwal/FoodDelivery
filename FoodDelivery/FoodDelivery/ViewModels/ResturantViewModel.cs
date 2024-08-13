using FoodDelivery.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.ViewModels
{
    public class ResturantViewModel
    {
        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Contacts { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public DateTime Joined { get; set; }

        [Required]
        [MaxLength(100)]
        public string OpeningHours { get; set; }

       

        
    }
}
