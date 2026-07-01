using B2B.DTOs.RequestDTOs.Category;
using B2B.DTOs.RequestDTOs.Product;
using B2B.DTOs.ResponseDtos.Product;
using B2B.Entities;
using B2B.Entities.Product;
using B2B.Entities.Users;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class CategoryService :ICategoryService
    {
        private readonly IGenericService<Category> _service;
        private readonly IBusinessService _BusinessService;
        private readonly IUserContextService _UserContextService;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IGenericService<Category> service, IBusinessService businessService, IUserContextService userContextService)
        {
            _service = service;
            _BusinessService = businessService;
            _UserContextService = userContextService;
        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryRequestDto dto)
        {
            var UserId = _UserContextService.GetUserId();
            var BusinessData = await _BusinessService.GetBusinessByUserIdAsync(UserId);
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                BusinessId = BusinessData.Id
            };
            await _service.CreateAsync(category);
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                BusinessId = category.BusinessId,
                BusinessName = BusinessData.BusinessName
            };
          
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            var userId = _UserContextService.GetUserId();
            var businessData = await _BusinessService.GetBusinessByUserIdAsync(userId);

            var Categories = await _categoryRepo.FindAsync(x => x.BusinessId == businessData.Id);
            
            return Categories.Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                BusinessId = category.BusinessId,
                Name = category.Name,
                BusinessName = category.Business?.BusinessName
             
            }).ToList();
        }



        public Task<Category> Get(Guid id) => _service.GetByIdAsync(id);
        public Task Update(Category category) => _service.UpdateAsync(category);
        public Task Delete(Guid id) => _service.DeleteAsync(id);
    }
}
