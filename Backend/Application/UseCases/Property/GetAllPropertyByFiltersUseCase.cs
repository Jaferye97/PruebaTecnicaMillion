using Application.Ports;
using Application.UseCases.Property.Interfaces;
using Domain.Models.Property;

namespace Application.UseCases.Property
{
    public class GetAllPropertyByFiltersUseCase : IGetAllPropertyByFiltersUseCase
    {
        private readonly IPropertyRepositoryPort _repository;

        public GetAllPropertyByFiltersUseCase(IPropertyRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropertyModel>> ExecuteAsync(string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice)
        {
            return await _repository.GetAllAsync(name, address, minPrice, maxPrice);
        }
    }
}
