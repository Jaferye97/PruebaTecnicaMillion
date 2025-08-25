using Domain.Commons;
using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IGetAllPropertyByFiltersUseCase
    {
        Task<PagedResult<PropertyModel>> ExecuteAsync(string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageNumber,
            int pageSize);
    }
}
