using B2B.Entities;
using B2B.Entities.Users;
using B2B.Services.Implementations;
using B2B.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerTypeController : ControllerBase
    {
        private readonly ISellerTypeService _service;

        public SellerTypeController(ISellerTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create(SellerType sellerType)
        {
            await _service.Create(sellerType);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SellerType sellerType)
        {
            await _service.Update(sellerType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
