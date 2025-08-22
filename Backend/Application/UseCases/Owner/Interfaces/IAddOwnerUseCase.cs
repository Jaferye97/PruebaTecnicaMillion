using Domain.Models.Owner;

namespace Application.UseCases.Owner.Interfaces
{
    public interface IAddOwnerUseCase
    {
        Task<OwnerModel> ExecuteAsync(OwnerModel model);
    }
}
