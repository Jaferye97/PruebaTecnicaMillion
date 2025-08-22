using Domain.Models.Property;

namespace Application.UseCases.Property.Interfaces
{
    public interface IGetAllPropertyByFiltersUseCase
    {
        Task<IEnumerable<PropertyModel>> ExecuteAsync(string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice);
    }
}
