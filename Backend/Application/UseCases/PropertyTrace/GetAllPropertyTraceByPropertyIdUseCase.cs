using Application.Ports;
using Application.UseCases.PropertyTrace.Interfaces;
using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace
{
    public class GetAllPropertyTraceByPropertyIdUseCase : IGetAllPropertyTraceByPropertyIdUseCase
    {
        private readonly IPropertyTraceRepositoryPort _repository;

        public GetAllPropertyTraceByPropertyIdUseCase(IPropertyTraceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropertyTraceModel>> ExecuteAsync(Guid propertyId)
        {
            return await _repository.GetAllByPropertyIdAsync(propertyId);
        }
    }
}
