using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace.Interfaces
{
    public interface IGetPropertyTraceByIdUseCase
    {
        Task<PropertyTraceModel?> ExecuteAsync(Guid id);
    }
}
