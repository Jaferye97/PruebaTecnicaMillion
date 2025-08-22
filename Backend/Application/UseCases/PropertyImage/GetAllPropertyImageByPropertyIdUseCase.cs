using Application.Ports;
using Application.UseCases.PropertyImage.Interfaces;
using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage
{
    public class GetAllPropertyImageByPropertyIdUseCase : IGetAllPropertyImageByPropertyIdUseCase
    {
        private readonly IPropertyImageRepositoryPort _repository;

        public GetAllPropertyImageByPropertyIdUseCase(IPropertyImageRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropertyImageModel>> ExecuteAsync(Guid propertyId)
        {
            return await _repository.GetAllByPropertyIdAsync(propertyId);
        }
    }
}
