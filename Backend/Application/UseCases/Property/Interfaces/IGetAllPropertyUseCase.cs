using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IGetAllPropertyUseCase
    {
        Task<IEnumerable<PropertyModel>> ExecuteAsync();
    }
}
