using Domain.Models.Owner;

namespace Application.UseCases.Owner.Interfaces
{
    public interface IGetAllOwnerUseCase
    {
        Task<IEnumerable<OwnerModel>> ExecuteAsync();
    }
}
