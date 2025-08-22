using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace.Interfaces
{
    public interface IGetAllPropertyTraceByPropertyIdUseCase
    {
        Task<IEnumerable<PropertyTraceModel>> ExecuteAsync(Guid propertyId);
    }
}
