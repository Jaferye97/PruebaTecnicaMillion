using Application.Ports;
using Application.UseCases.PropertyImage.Interfaces;
using Domain.Models.PropertyImage;

namespace Application.UseCases.PropertyImage
{
    public class ToggleEnabledPropertyImageUseCase : IToggleEnabledPropertyImageUseCase
    {
        private readonly IPropertyImageRepositoryPort _repository;

        public ToggleEnabledPropertyImageUseCase(IPropertyImageRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PropertyImageModel?> ExecuteAsync(Guid id)
        {
            return await _repository.ToggleEnabledAsync(id);
        }
    }
}
