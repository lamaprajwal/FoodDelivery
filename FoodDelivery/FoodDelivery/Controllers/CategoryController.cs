using FoodDelivery.Models;
using FoodDelivery.Repository;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _repo = categoryRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddCategory(CategoryViewModel cvm)
        {
            var res = new Category
            {
                Name=cvm.CategoryName,
                RestaurantID=cvm.ResturantId,
            };

            _repo.AddCategory(res);
            await _repo.SaveChangesAsync();
            return Ok(res);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _repo.DeleteCategory(id);
            await _repo.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("")]
        public ActionResult<List<Category>> GetCategory()
        {
            return _repo.GetAllCategory();
           
        }

        [HttpGet("id")]
        public IActionResult GetCategory(int id)
        {
            var res = _repo.GetCategory(id);
            return Ok(res);
        }





    }
}
