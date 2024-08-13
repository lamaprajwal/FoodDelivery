using FoodDelivery.Models;

namespace FoodDelivery.Repository
{
    public interface IResturantRepository
    {
        void AddResturant(Restaurant resturant);
        List<Restaurant> GetAllResturants();

        void DeleteResturant(int id);

        Restaurant GetResturant(int id);



        Task<bool> SaveChangesAsync();
    }
}
