using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task GetAllAsync();
        IEnumerable<Category> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryById(int id);
        Task UpdateCategory(Category category);
    }
}