using Domain.Models.Property;

namespace Application.Ports
{
    public interface IPropertyRepositoryPort
    {
        Task<IEnumerable<PropertyModel>> GetAllAsync(
            string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice);
        Task<IEnumerable<PropertyModel>> GetAllAsync();
        Task<IEnumerable<PropertyModel>> GetAllByOwnerIdAsync(Guid ownerId);
        Task<PropertyModel> AddAsync(PropertyModel model);
        Task<PropertyModel> UpdateAsync(PropertyModel model);
    }
}
