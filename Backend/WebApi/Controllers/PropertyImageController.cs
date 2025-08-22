using Application.UseCases.PropertyImage.Interfaces;
using Domain.Models.PropertyImage;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IAddPropertyImageUseCase _addPropertyImageUseCase;
        private readonly IGetAllPropertyImageByPropertyIdUseCase _getAllByPropertyIdUseCase;
        private readonly IToggleEnabledPropertyImageUseCase _toggleEnabledUseCase;

        public PropertyImageController(IToggleEnabledPropertyImageUseCase toggleEnabledUseCase, IGetAllPropertyImageByPropertyIdUseCase getAllByPropertyIdUseCase, IAddPropertyImageUseCase addPropertyImageUseCase)
        {
            _toggleEnabledUseCase = toggleEnabledUseCase;
            _getAllByPropertyIdUseCase = getAllByPropertyIdUseCase;
            _addPropertyImageUseCase = addPropertyImageUseCase;
        }

        [HttpGet("GetAllByPropertyId/{propertyId}")]
        public async Task<IActionResult> GetAllByPropertyIdAsync(Guid propertyId)
        {
            var result = await _getAllByPropertyIdUseCase.ExecuteAsync(propertyId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PropertyImageModel model)
        {
            var created = await _addPropertyImageUseCase.ExecuteAsync(model);
            return Ok(created);
        }

        [HttpPut("ToggleEnabled/{id}")]
        public async Task<IActionResult> ToggleEnabledAsync(Guid id)
        {
            var updated = await _toggleEnabledUseCase.ExecuteAsync(id);
            if (updated == null) return NotFound();

            return Ok(updated);
        }
    }
}
