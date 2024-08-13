using FoodDelivery.Models;

namespace FoodDelivery.Repository
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        List<Category> GetAllCategory();

        void DeleteCategory(int id);

        Category GetCategory(int id);



        Task<bool> SaveChangesAsync();
    }
}
