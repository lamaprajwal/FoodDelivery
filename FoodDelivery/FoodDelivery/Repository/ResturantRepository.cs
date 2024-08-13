using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.ViewModels;

namespace FoodDelivery.Repository
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly AppDbContext _context;

        public ResturantRepository(AppDbContext context)
        {
            _context = context;
        }
       

        public void AddResturant(Restaurant resturant)
        {

            _context.Restaurants.Add(resturant);
        }

        public void DeleteResturant(int id)
        {
            _context.Restaurants.Remove(GetResturant(id));  
        }

        public List<Restaurant> GetAllResturants()
        {
            return _context.Restaurants.ToList();
           
        }

        public Restaurant GetResturant(int id)
        {
            return _context.Restaurants.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
           if(await _context.SaveChangesAsync()>0)
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
