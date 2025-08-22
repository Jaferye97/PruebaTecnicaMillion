using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ReporitoryMongoDb.Entities.Constants;
using ReporitoryMongoDb.Repositories.Interfaces;
using static MongoDB.Driver.WriteConcern;

namespace ReporitoryMongoDb.Repositories
{
    public abstract class BaseRepository<TDocument, TModel, TPrimary> : IBaseRepository<TDocument, TModel, TPrimary>
    where TDocument : class, IDocument<TPrimary>
    where TModel : class
    {
        private readonly Func<TDocument, TModel> _toModel;
        private readonly Func<TModel, TDocument> _toDocument;

        protected readonly IMongoCollection<TDocument> _collection;

        protected BaseRepository(
        IMongoDatabase database,
        string collectionName,
        Func<TDocument, TModel> toModel,
        Func<TModel, TDocument> toEntity)
        {
            _collection = database.GetCollection<TDocument>(collectionName);
            _toModel = toModel;
            _toDocument = toEntity;
        }

        public virtual async Task<TModel?> GetAsync(TPrimary id)
        {
            var document = await _collection
                .Find(x => x.Id!.Equals(id))
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return document is null ? null : _toModel(document);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var documents = await _collection
                .Find(FilterDefinition<TDocument>.Empty)
                .ToListAsync()
                .ConfigureAwait(false);

            return documents.Select(_toModel).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids)
        {
            var filter = Builders<TDocument>.Filter.In(x => x.Id, ids);
            var documents = await _collection
                .Find(filter)
                .ToListAsync()
                .ConfigureAwait(false);

            return documents.Select(_toModel).ToList();
        }

        public virtual async Task<TModel> AddAsync(TModel model)
        {
            var document = _toDocument(model);
            await _collection.InsertOneAsync(document).ConfigureAwait(false);
            return _toModel(document);
        }

        public virtual async Task<IEnumerable<TModel>> AddAsync(IEnumerable<TModel> models)
        {
            var documents = models.Select(_toDocument).ToList();
            if (documents.Count == 0) return models;

            await _collection.InsertManyAsync(documents).ConfigureAwait(false);
            return documents.Select(_toModel).ToList();
        }

        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            var document = _toDocument(model);
            var result = await _collection
                .ReplaceOneAsync(x => x.Id!.Equals(document.Id), document)
                .ConfigureAwait(false);

            if (result.MatchedCount == 0)
                throw new KeyNotFoundException($"No existe entidad con Id '{document.Id}'.");

            return _toModel(document);
        }

        public async Task<IEnumerable<TModel>> UpdateAsync(IEnumerable<TModel> models)
        {
            var writes = models.Select(model =>
            {
                var document = _toDocument(model);
                var filter = Builders<TDocument>.Filter.Eq(x => x.Id, document.Id);
                return new ReplaceOneModel<TDocument>(filter, document);
            });

            await _collection.BulkWriteAsync(writes);

            return models;
        }

        public async Task DeleteByIdAsync(TPrimary id)
        {
            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<TModel> DeleteAsync(TModel model)
        {
            var document = _toDocument(model);

            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, document.Id);

            await _collection.DeleteOneAsync(filter);

            return model;
        }

        public async Task<IEnumerable<TModel>> DeleteAsync(IEnumerable<TModel> models)
        {
            var ids = models
                        .Select(m => _toDocument(m).Id)
                        .ToList();

            if (ids.Count == 0)
                return Enumerable.Empty<TModel>();

            var filter = Builders<TDocument>.Filter.In(x => x.Id, ids);

            await _collection.DeleteManyAsync(filter);

            return models;
        }

        public async Task<IEnumerable<TModel>> GetWithPredicateAsync(Expression<Func<TDocument, bool>> predicate)
        {
            var documents = await _collection
                .Find(predicate)
                .ToListAsync()
                .ConfigureAwait(false);

            return documents.Select(_toModel).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAsync(
            Expression<Func<TDocument, bool>>? filter = null,
            Func<IQueryable<TDocument>, IOrderedQueryable<TDocument>>? orderBy = null)
        {
            IQueryable<TDocument> query = _collection.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            var documents = await query.ToListAsync().ConfigureAwait(false);
            return documents.Select(_toModel).ToList();
        }

        public async Task<TModel?> GetUniqueAsync(
            Expression<Func<TDocument, bool>>? filter = null,
            Func<IQueryable<TDocument>, IOrderedQueryable<TDocument>>? orderBy = null)
        {
            var list = await GetAsync(filter, orderBy).ConfigureAwait(false);
            return list.FirstOrDefault();
        }

        public async Task<IEnumerable<TModel>> FindByIdsAsync(IEnumerable<TPrimary> ids)
        {
            var filter = Builders<TDocument>.Filter.In(d => d.Id, ids);
            var documents = await _collection.Find(filter).ToListAsync();
            return documents.Select(_toModel);
        }

        public async Task<long> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            var filter = Builders<TDocument>.Filter.Where(predicate);
            var count = await _collection.CountDocumentsAsync(filter).ConfigureAwait(false);
            return count;
        }

        public async Task<bool> ExistsAsync(TPrimary id)
        {
            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, id);
            return await _collection.Find(filter).AnyAsync();
        }
    }
}
