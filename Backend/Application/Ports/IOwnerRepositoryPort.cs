using Domain.Models.Owner;

namespace Application.Ports
{
    public interface IOwnerRepositoryPort
    {
        Task<OwnerModel?> GetAsync(Guid id);
        Task<IEnumerable<OwnerModel>> GetAllAsync();
        Task<OwnerModel> AddAsync(OwnerModel model);
        Task<OwnerModel> UpdateAsync(OwnerModel model);
    }
}
