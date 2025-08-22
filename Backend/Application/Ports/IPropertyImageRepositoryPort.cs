using Domain.Models.PropertyImage;

namespace Application.Ports
{
    public interface IPropertyImageRepositoryPort
    {
        Task<IEnumerable<PropertyImageModel>> GetAllByPropertyIdAsync(Guid propertyId);
        Task<PropertyImageModel> AddAsync(PropertyImageModel model);
        Task<PropertyImageModel?> ToggleEnabledAsync(Guid id);
    }
}
