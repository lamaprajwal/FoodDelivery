using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.ViewModels;

namespace FoodDelivery.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {

            _context = context;

        }
        public void AddCategory(Category category)
        {

            _context.Categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            _context.Categories.Remove(GetCategory(id));
        }

        public List<Category> GetAllCategory()
        {
            var categoryList = _context.Categories.Include(ctg => ctg.Restaurant).ToList();
             return categoryList;
                              

        }

        public Category GetCategory(int id)
        {
            return _context.Categories
                .Include(ctg => ctg.Restaurant)
                .FirstOrDefault(ctg => ctg.CategoryId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
    }
}
