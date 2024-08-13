using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {  get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("RestaurantID")]
        public int RestaurantID { get; set; }
       
        public virtual Restaurant? Restaurant { get; set; }
    }
       

}
