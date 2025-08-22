using Application.Ports;
using Domain.Models.PropertyImage;
using MongoDB.Driver;
using ReporitoryMongoDb.Documents;
using ReporitoryMongoDb.Mappers;

namespace ReporitoryMongoDb.Repositories
{
    public class PropertyImageRepository : BaseRepository<PropertyImageDocument, PropertyImageModel, Guid>, IPropertyImageRepositoryPort
    {
        public PropertyImageRepository(IMongoDatabase database) : base(database, "PropertyImage", entity => entity.ToDomain(), entity => entity.ToDocument())
        {
        }

        public Task<IEnumerable<PropertyImageModel>> GetAllByPropertyIdAsync(Guid propertyId)
        {
            return GetWithPredicateAsync(doc => doc.PropertyId == propertyId);
        }

        public async Task<PropertyImageModel?> ToggleEnabledAsync(Guid id)
        {
            var document = await GetAsync(id);

            if (document == null)
            {
                return null;
            }

            document.Enabled = !document.Enabled;

            return await UpdateAsync(document);
        }
    }
}
