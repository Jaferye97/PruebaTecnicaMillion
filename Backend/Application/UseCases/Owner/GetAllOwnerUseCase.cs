using Application.Ports;
using Application.UseCases.Owner.Interfaces;
using Domain.Models.Owner;

namespace Application.UseCases.Owner
{
    public class GetAllOwnerUseCase : IGetAllOwnerUseCase
    {
        private readonly IOwnerRepositoryPort _repository;

        public GetAllOwnerUseCase(IOwnerRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OwnerModel>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
