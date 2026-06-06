using B2B.Entities.Users;
using B2B.Services.Implementations;
using B2B.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            await _service.Create(role);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            await _service.Update(role);
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
