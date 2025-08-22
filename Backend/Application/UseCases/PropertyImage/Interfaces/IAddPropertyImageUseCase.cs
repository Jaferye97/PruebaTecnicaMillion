using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage.Interfaces
{
    public interface IAddPropertyImageUseCase
    {
        Task<PropertyImageModel> ExecuteAsync(PropertyImageModel model);
    }
}
