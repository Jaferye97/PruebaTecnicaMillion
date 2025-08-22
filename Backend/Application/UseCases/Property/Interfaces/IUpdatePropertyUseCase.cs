using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IUpdatePropertyUseCase
    {
        Task<PropertyModel> ExecuteAsync(PropertyModel model);
    }
}
