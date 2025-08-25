using Application.Ports;
using Application.UseCases.Property.Interfaces;
using Domain.Commons;
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

        public async Task<PagedResult<PropertyModel>> ExecuteAsync(string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageNumber,
            int pageSize)
        {
            var result = await _repository.GetAllAsync(name, address, minPrice, maxPrice, pageNumber, pageSize);

            return new PagedResult<PropertyModel>
            {
                TotalRecords = result.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = result
            };
        }
    }
}
