using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage.Interfaces
{
    public interface IToggleEnabledPropertyImageUseCase
    {
        Task<PropertyImageModel?> ExecuteAsync(Guid id);
    }
}
