using FoodDelivery.Models;
using FoodDelivery.Repository;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ResturantController : Controller
    {
        public readonly IResturantRepository _repo;

        public ResturantController(IResturantRepository repo)
        {
            _repo = repo;
        }

       


        [HttpPost("")]
        public async Task<IActionResult> AddResturant(ResturantViewModel rvm)
        {
            var res = new Restaurant
            {
                RestaurantName = rvm.RestaurantName,
                Contacts = rvm.Contacts,
                Address = rvm.Address,
                Joined = rvm.Joined,
                OpeningHours = rvm.OpeningHours,
            };

            _repo.AddResturant(res);
            await _repo.SaveChangesAsync();
            return Ok(res);
        }

        [HttpGet("")]

        public IActionResult GetResturants()
        {
            var res = _repo.GetAllResturants();
            return Ok(res);


        }
        [HttpGet("id")]

        public IActionResult GetRestaurant(int id)
        { 
            var res=_repo.GetResturant(id);
            return Ok(res);
            
        }
        [HttpDelete("id")]

        public async Task<IActionResult> DeleteResturant(int id)
        {
            _repo.DeleteResturant(id);
            await _repo.SaveChangesAsync();
            return Ok();

        }
        

    }
}
