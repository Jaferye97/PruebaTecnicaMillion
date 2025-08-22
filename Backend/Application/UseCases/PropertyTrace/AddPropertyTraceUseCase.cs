using Application.Ports;
using Application.UseCases.PropertyTrace.Interfaces;
using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace
{
    public class AddPropertyTraceUseCase : IAddPropertyTraceUseCase
    {
        private readonly IPropertyTraceRepositoryPort _repository;

        public AddPropertyTraceUseCase(IPropertyTraceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PropertyTraceModel> ExecuteAsync(PropertyTraceModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
