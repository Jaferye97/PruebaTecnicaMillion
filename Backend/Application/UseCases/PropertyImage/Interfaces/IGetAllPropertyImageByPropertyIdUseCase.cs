using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage.Interfaces
{
    public interface IGetAllPropertyImageByPropertyIdUseCase
    {
        Task<IEnumerable<PropertyImageModel>> ExecuteAsync(Guid propertyId);
    }
}
