using Application.UseCases.PropertyTrace.Interfaces;
using Domain.Models.PropertyTrace;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTraceController : ControllerBase
    {
        private readonly IGetAllByPropertyIdUseCase _getAllByPropertyIdUseCase;
        private readonly IGetPropertyTraceByIdUseCase _getPropertyTraceByIdUseCase;
        private readonly IAddPropertyTraceUseCase _addPropertyTraceUseCase;

        public PropertyTraceController(IGetAllByPropertyIdUseCase getAllByPropertyIdUseCase, IAddPropertyTraceUseCase addPropertyTraceUseCase, IGetPropertyTraceByIdUseCase getPropertyTraceByIdUseCase)
        {
            _getAllByPropertyIdUseCase = getAllByPropertyIdUseCase;
            _addPropertyTraceUseCase = addPropertyTraceUseCase;
            _getPropertyTraceByIdUseCase = getPropertyTraceByIdUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var PropertyTrace = await _getPropertyTraceByIdUseCase.ExecuteAsync(id);
            if (PropertyTrace == null) return NotFound();
            return Ok(PropertyTrace);
        }

        [HttpGet("GetAllByPropertyId/{propertyId}")]
        public async Task<IActionResult> GetAllByPropertyId(Guid propertyId)
        {
            var result = await _getAllByPropertyIdUseCase.ExecuteAsync(propertyId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyTraceModel model)
        {
            var created = await _addPropertyTraceUseCase.ExecuteAsync(model);
            return Ok(created);
        }

    }
}
