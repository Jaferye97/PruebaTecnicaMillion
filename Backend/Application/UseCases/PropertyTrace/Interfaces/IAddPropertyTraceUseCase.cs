using Domain.Models.PropertyTrace;

namespace Application.UseCases.PropertyTrace.Interfaces
{
    public interface IAddPropertyTraceUseCase
    {
        Task<PropertyTraceModel> ExecuteAsync(PropertyTraceModel model);
    }
}
