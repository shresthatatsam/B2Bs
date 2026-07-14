using B2B.DTOs.RequestDTOs.Product;
using B2B.DTOs.ResponseDtos.Product;

namespace B2B.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);

        Task<List<ProductResponseDto>> GetAllAsync();

        Task<ProductResponseDto> GetByIdAsync(Guid id);

        Task<ProductResponseDto> UpdateAsync(Guid id, ProductRequestDto dto);

        Task<List<ProductResponseDto>> GetProductByCategoryId(Guid id);
        Task DeleteAsync(Guid id);
    }
}
