using Application.UseCases.Property.Interfaces;
using Domain.Models.Property;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IAddPropertyUseCase _addPropertyUseCase;
        private readonly IGetAllPropertyByFiltersUseCase _getAllPropertyByFiltersUseCase;
        private readonly IGetAllPropertyByOwnerIdUseCase _getAllPropertyByOwnerIdUseCase;
        private readonly IGetAllPropertyUseCase _getAllPropertyUseCase;
        private readonly IUpdatePropertyUseCase _updatePropertyUseCase;

        public PropertyController(
            IUpdatePropertyUseCase updatePropertyUseCase,
            IGetAllPropertyUseCase getAllPropertyUseCase,
            IGetAllPropertyByOwnerIdUseCase getAllPropertyByOwnerIdUseCase,
            IGetAllPropertyByFiltersUseCase getAllPropertyByFiltersUseCase,
            IAddPropertyUseCase addPropertyUseCase)
        {
            _updatePropertyUseCase = updatePropertyUseCase;
            _getAllPropertyUseCase = getAllPropertyUseCase;
            _getAllPropertyByOwnerIdUseCase = getAllPropertyByOwnerIdUseCase;
            _getAllPropertyByFiltersUseCase = getAllPropertyByFiltersUseCase;
            _addPropertyUseCase = addPropertyUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _getAllPropertyUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("GetAllByOwnerId/{ownerId}")]
        public async Task<IActionResult> GetAllByPropertyIdAsync([FromRoute] Guid ownerId)
        {
            var result = await _getAllPropertyByOwnerIdUseCase.ExecuteAsync(ownerId);
            return Ok(result);
        }

        [HttpGet("GetAllFilters")]
        public async Task<IActionResult> GetAllFiltersAsync([FromQuery] string? name, [FromQuery] string? address,
                                            [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var result = await _getAllPropertyByFiltersUseCase.ExecuteAsync(name, address, minPrice, maxPrice);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PropertyModel model)
        {
            var created = await _addPropertyUseCase.ExecuteAsync(model);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PropertyModel model)
        {
            var created = await _updatePropertyUseCase.ExecuteAsync(model);
            return Ok(created);
        }
    }
}
