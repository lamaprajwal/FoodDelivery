namespace FoodDelivery.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contacts { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public DateTime Joined { get; set; }

        [Required]
        [MaxLength(100)]
        public string OpeningHours { get; set; }
        // Navigation property
       
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<Category?> Categories { get; set; }

    }

}
