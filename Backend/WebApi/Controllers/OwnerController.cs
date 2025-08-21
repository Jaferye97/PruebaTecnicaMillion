using Application.UseCases.Owner.Interfaces;
using Domain.Models.Owner;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IGetAllOwnerUseCase _getAllOwnerUseCase;
        private readonly IGetOwnerByIdUseCase _getOwnerByIdUseCase;
        private readonly IAddOwnerUseCase _addOwnerUseCase;
        private readonly IUpdateOwnerUseCase _updateOwnerUseCase;

        public OwnerController(IGetAllOwnerUseCase getAllOwnerUseCase, IGetOwnerByIdUseCase getOwnerByIdUseCase, IAddOwnerUseCase addOwnerUseCase, IUpdateOwnerUseCase updateOwnerUseCase)
        {
            _getAllOwnerUseCase = getAllOwnerUseCase;
            _getOwnerByIdUseCase = getOwnerByIdUseCase;
            _addOwnerUseCase = addOwnerUseCase;
            _updateOwnerUseCase = updateOwnerUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getAllOwnerUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var owner = await _getOwnerByIdUseCase.ExecuteAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OwnerModel model)
        {
            var created = await _addOwnerUseCase.ExecuteAsync(model);
            return Ok(created);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] OwnerModel model)
        {
            var owner = await _getOwnerByIdUseCase.ExecuteAsync(model.Id);
            if (owner == null) return NotFound();

            var updated = await _updateOwnerUseCase.ExecuteAsync(model);
            return Ok(owner);
        }
    }
}
