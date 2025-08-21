using Application.Ports;
using Domain.Models.Owner;
using MongoDB.Driver;
using ReporitoryMongoDb.Documents;
using ReporitoryMongoDb.Mappers;

namespace ReporitoryMongoDb.Repositories
{
    public class OwnerRepository : BaseRepository<OwnerDocument, OwnerModel, Guid>, IOwnerRepositoryPort
    {
        public OwnerRepository(IMongoDatabase database) : base(database, "Owner", entity => entity.ToDomain(), entity => entity.ToDocument())
        {
        }
    }
}
