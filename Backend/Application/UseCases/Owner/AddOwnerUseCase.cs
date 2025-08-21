using Application.Ports;
using Application.UseCases.Owner.Interfaces;
using Domain.Models.Owner;

namespace Application.UseCases.Owner
{
    public class AddOwnerUseCase : IAddOwnerUseCase
    {
        private readonly IOwnerRepositoryPort _repository;

        public AddOwnerUseCase(IOwnerRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<OwnerModel> ExecuteAsync(OwnerModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
