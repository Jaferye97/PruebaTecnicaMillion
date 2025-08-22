using Application.Ports;
using Application.UseCases.Property.Interfaces;
using Domain.Models.Property;

namespace Application.UseCases.Property
{
    public class GetAllPropertyByOwnerIdUseCase : IGetAllPropertyByOwnerIdUseCase
    {
        private readonly IPropertyRepositoryPort _repository;

        public GetAllPropertyByOwnerIdUseCase(IPropertyRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropertyModel>> ExecuteAsync(Guid ownerId)
        {
            return await _repository.GetAllByOwnerIdAsync(ownerId);
        }
    }
}
