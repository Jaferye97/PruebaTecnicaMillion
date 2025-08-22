using Application.Ports;
using Application.UseCases.PropertyTrace.Interfaces;
using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace
{
    public class GetPropertyTraceByIdUseCase : IGetPropertyTraceByIdUseCase
    {
        private readonly IPropertyTraceRepositoryPort _repository;

        public GetPropertyTraceByIdUseCase(IPropertyTraceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PropertyTraceModel?> ExecuteAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
