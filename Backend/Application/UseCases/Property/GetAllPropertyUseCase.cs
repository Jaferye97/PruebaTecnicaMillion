using Application.Ports;
using Application.UseCases.Property.Interfaces;
using Domain.Models.Property;

namespace Application.UseCases.Property
{
    public class GetAllPropertyUseCase : IGetAllPropertyUseCase
    {
        private readonly IPropertyRepositoryPort _repository;

        public GetAllPropertyUseCase(IPropertyRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropertyModel>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
