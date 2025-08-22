using Application.Ports;
using Application.UseCases.PropertyImage.Interfaces;
using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage
{
    public class AddPropertyImageUseCase : IAddPropertyImageUseCase
    {
        private readonly IPropertyImageRepositoryPort _repository;

        public AddPropertyImageUseCase(IPropertyImageRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PropertyImageModel> ExecuteAsync(PropertyImageModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
