using B2B.DTOs.RequestDTOs.Category;
using B2B.Entities;
using B2B.Entities.Users;

namespace B2B.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<Category> Get(Guid id);
        Task<CategoryResponseDto> CreateAsync(CategoryRequestDto dto);
        Task<List<CategoryResponseDto>> GetAllUserCategoryAsync();
        Task Update(Category category);
        Task Delete(Guid id);
    }
}
