using Application.Ports;
using Application.UseCases.Owner.Interfaces;
using Domain.Models.Owner;

namespace Application.UseCases.Owner
{
    public class GetOwnerByIdUseCase : IGetOwnerByIdUseCase
    {
        private readonly IOwnerRepositoryPort _repository;

        public GetOwnerByIdUseCase(IOwnerRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<OwnerModel?> ExecuteAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
