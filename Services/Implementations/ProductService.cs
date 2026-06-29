using B2B.DTOs.RequestDTOs.Product;
using B2B.DTOs.ResponseDtos.Product;
using B2B.Entities;
using B2B.Entities.Product;
using B2B.Repositories.Interfaces;
using B2B.Services.Interfaces;

namespace B2B.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IGenericService<Product> _service;
        private readonly IGenericService<ProductImage> _imageRepos;
        private readonly IImageService _imageService;
        private readonly IRepository<ProductImage> _imageRepo;
        private readonly IBusinessService _BusinessService;
        private readonly IUserContextService _UserContextService;

        public ProductService(
            IGenericService<Product> service,
            IGenericService<ProductImage> imageRepos,
            IImageService imageService,
            IRepository<ProductImage> imageRepo,
            IBusinessService businessService,
            IUserContextService userContextService)
        {
            _service = service;
            _imageRepos = imageRepos;
            _imageService = imageService;
            _imageRepo = imageRepo;
            _BusinessService = businessService;
            _UserContextService = userContextService;
        }

        public async Task<ProductResponseDto> CreateAsync(ProductRequestDto dto)
        {
            var UserId = _UserContextService.GetUserId();
            var BusinessData = await _BusinessService.GetBusinessByUserIdAsync(UserId);
            var product = new Product
            {
                Id = Guid.NewGuid(),
                BusinessId = BusinessData.Id,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow
            };

            await _service.CreateAsync(product);

            var imageUrls = new List<string>();

            if (dto.Images != null)
            {
                foreach (var image in dto.Images)
                {
                    var url = await _imageService
                        .UploadAsync(image, "products");

                    imageUrls.Add(url);

                    await _imageRepos.CreateAsync(new ProductImage
                    {
                        ProductId = product.Id,
                        ImageUrl = url
                    });
                }
            }

            return new ProductResponseDto
            {
                Id = product.Id,
                BusinessId = product.BusinessId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Images = imageUrls?.Select(x => new ProductImageDto
                {
                    ImageUrl = x
                }).ToList() ?? new List<ProductImageDto>()
            };
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _service.GetAllAsync();

            var productImages = await _imageRepo.FindAsync(x => true);

            var imageLookup = productImages
                .GroupBy(x => x.ProductId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(i => new ProductImageDto
                    {
                        ImageUrl = i.ImageUrl
                    }).ToList()
                );

            return products.Select(product => new ProductResponseDto
            {
                Id = product.Id,
                BusinessId = product.BusinessId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Images = imageLookup.ContainsKey(product.Id)
                    ? imageLookup[product.Id]
                    : new List<ProductImageDto>()
            }).ToList();
        }

        public async Task<ProductResponseDto> GetByIdAsync(Guid id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return null;

            var images = await _imageRepo.FindAsync(x => x.ProductId == id);

            return new ProductResponseDto
            {
                Id = product.Id,
                BusinessId = product.BusinessId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Images = images.Select(x => new ProductImageDto
                {
                    ImageUrl = x.ImageUrl
                }).ToList()
            };
        }
        public async Task<ProductResponseDto> UpdateAsync(Guid id, ProductRequestDto dto)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return null;

            product.BusinessId = dto.BusinessId;
            product.CategoryId = dto.CategoryId;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Status = dto.Status;

            await _service.UpdateAsync(product);

            return await GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var productImages = await _imageRepo.FindAsync(x => x.ProductId == id);

            foreach (var image in productImages)
            {
                await _imageRepos.DeleteAsync(image.Id);
            }

            await _service.DeleteAsync(id);
        }
    }
}
