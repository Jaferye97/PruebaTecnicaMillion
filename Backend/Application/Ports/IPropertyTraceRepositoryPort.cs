using Domain.Models.PropertyTrace;

namespace Application.Ports
{
    public interface IPropertyTraceRepositoryPort
    {
        Task<PropertyTraceModel?> GetAsync(Guid id);
        Task<IEnumerable<PropertyTraceModel>> GetAllByPropertyIdAsync(Guid propertyId);
        Task<PropertyTraceModel> AddAsync(PropertyTraceModel model);
    }
}
