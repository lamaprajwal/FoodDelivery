using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FoodDelivery.Repository
{
    public class MenuItemsRepository : IMenuItemsRepository
    {
        private readonly AppDbContext _context;

        public MenuItemsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddItems(MenuItem items)
        {
            if(_context.MenuItems.Where(r=>r.ResturantId==items.ResturantId).Any(m=>m.Item==items.Item))
            {
                throw new Exception("Menu Item Name already Exist!");
            }
            _context.MenuItems.Add(items);
            
        }
        public MenuItem DeleteItems(int id)
        {
            var item=_context.MenuItems.Include(m=>m.Resturant)
                .FirstOrDefault(m=>m.Id==id); 
            _context.MenuItems.Remove(item);
            return item;
            
        }
        public List<MenuItem> GetAllItems()
        {
          return _context.MenuItems.Include(m=>m.Resturant)
                .Include(m=>m.Category).ToList();
            
        }

        public MenuItem? GetItems(int id)
        {
            return _context
                .MenuItems
                .Include(m=>m.Resturant)
                .Include(m=>m.Category)
                .FirstOrDefault(m=> m.Id==id);  

            
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
