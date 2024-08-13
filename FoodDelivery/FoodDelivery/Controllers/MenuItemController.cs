using FoodDelivery.Models;
using FoodDelivery.Repository;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemsRepository _repo;

        public MenuItemController(IMenuItemsRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddMenuItem(MenuItemViewModel mvm)
        {
            var menuitem = new MenuItem
            {
                Item=mvm.Item,
                Price=mvm.Price,
                ResturantId=mvm.ResturantId,
                CategoryId=mvm.CategoryId
                
            };
           

            _repo.AddItems(menuitem);
            
            await _repo.SaveChangesAsync();
            return Ok(menuitem);
        }
    [HttpGet("")]
    public async Task<IActionResult> GetAllMenuItems()
    {
       var res= _repo.GetAllItems();
        return Ok(res);
    }
        [HttpDelete("id")]
public async Task<IActionResult> Delete(int id)
        {
            var res=_repo.DeleteItems(id);
            await _repo.SaveChangesAsync();
            return Ok(res);
        }



    }
}

        


