using Application.Ports;
using Domain.Models.PropertyTrace;
using MongoDB.Driver;
using ReporitoryMongoDb.Documents;
using ReporitoryMongoDb.Mappers;

namespace ReporitoryMongoDb.Repositories
{
    public class PropertyTraceRepository : BaseRepository<PropertyTraceDocument, PropertyTraceModel, Guid>, IPropertyTraceRepositoryPort
    {
        public PropertyTraceRepository(IMongoDatabase database) : base(database, "PropertyTrace", entity => entity.ToDomain(), entity => entity.ToDocument())
        {
        }

        public Task<IEnumerable<PropertyTraceModel>> GetAllByPropertyIdAsync(Guid propertyId)
        {
            return GetWithPredicateAsync(doc => doc.PropertyId == propertyId);
        }
    }
}
