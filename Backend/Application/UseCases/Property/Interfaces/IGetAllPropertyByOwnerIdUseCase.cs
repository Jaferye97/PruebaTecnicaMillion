using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IGetAllPropertyByOwnerIdUseCase
    {
        Task<IEnumerable<PropertyModel>> ExecuteAsync(Guid ownerId);
    }
}
