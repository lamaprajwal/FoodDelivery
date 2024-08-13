using FoodDelivery.Models;

namespace FoodDelivery.Repository
{
    public interface IMenuItemsRepository
    {
        void AddItems(MenuItem items);
        List<MenuItem> GetAllItems();

        MenuItem DeleteItems(int id);

        MenuItem? GetItems(int id);

        Task<bool> SaveChangesAsync();
    }
}
