using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace.Interfaces
{
    public interface IGetAllByPropertyIdUseCase
    {
        Task<IEnumerable<PropertyTraceModel>> ExecuteAsync(Guid propertyId);
    }
}
