using Domain.Models.Owner;

namespace Application.UseCases.Owner.Interfaces
{
    public interface IUpdateOwnerUseCase
    {
        Task<OwnerModel> ExecuteAsync(OwnerModel model);
    }
}
