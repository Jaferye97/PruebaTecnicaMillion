using Domain.Models.Owner;

namespace Application.UseCases.Owner.Interfaces
{
    public interface IGetOwnerByIdUseCase
    {
        Task<OwnerModel?> ExecuteAsync(Guid id);
    }
}
