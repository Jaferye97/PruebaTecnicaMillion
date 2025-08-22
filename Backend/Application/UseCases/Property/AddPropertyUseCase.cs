using Application.Ports;
using Application.UseCases.Property.Interfaces;
using Domain.Models.Property;

namespace Application.UseCases.Property
{
    public class AddPropertyUseCase : IAddPropertyUseCase
    {
        private readonly IPropertyRepositoryPort _repository;

        public AddPropertyUseCase(IPropertyRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PropertyModel> ExecuteAsync(PropertyModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
