using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryCreateDTO categoryDTO);
        Task DeleteCategory(CategoryDeleteDTO categoryDeleteDTO);
        Task<IEnumerable<CategoryListDTO>> GetCategoriesAsync();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
    }
}