using System;
using System.Linq.Expressions;
using Application.Ports;
using Domain.Models.Property;
using MongoDB.Driver;
using ReporitoryMongoDb.Documents;
using ReporitoryMongoDb.Extensions;
using ReporitoryMongoDb.Mappers;

namespace ReporitoryMongoDb.Repositories
{
    public class PropertyRepository : BaseRepository<PropertyDocument, PropertyModel, Guid>, IPropertyRepositoryPort
    {
        public PropertyRepository(IMongoDatabase database) : base(database, "Property", entity => entity.ToDomain(), entity => entity.ToDocument())
        {
        }

        public async Task<IEnumerable<PropertyModel>> GetAllAsync(
            string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice,
            int pageNumber,
            int pageSize)
        {
            Expression<Func<PropertyDocument, bool>> filter = p => true;

            if (!string.IsNullOrWhiteSpace(name))
                filter = filter.AndAlso(p => p.Name.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrWhiteSpace(address))
                filter = filter.AndAlso(p => p.Address.ToLower().Contains(address.ToLower()));

            if (minPrice.HasValue)
                filter = filter.AndAlso(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                filter = filter.AndAlso(p => p.Price <= maxPrice.Value);


            var documents = await _collection
                .Find(filter)
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return documents.Select(entity => entity.ToDomain()).ToList();
        }

        public Task<IEnumerable<PropertyModel>> GetAllByOwnerIdAsync(Guid ownerId)
        {
            return GetWithPredicateAsync(doc => doc.OwnerId == ownerId);
        }
    }
}
