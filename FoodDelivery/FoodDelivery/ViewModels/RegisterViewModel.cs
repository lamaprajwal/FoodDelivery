using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name {  get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
    }
}
