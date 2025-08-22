using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IAddPropertyUseCase
    {
        Task<PropertyModel> ExecuteAsync(PropertyModel model);
    }
}
