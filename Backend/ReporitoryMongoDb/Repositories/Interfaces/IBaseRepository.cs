using System.Linq.Expressions;

namespace ReporitoryMongoDb.Repositories.Interfaces
{
    public interface IBaseRepository<TDocument, TModel, in TPrimary>
    where TDocument : class
    where TModel : class
    {
        Task<TModel?> GetAsync(TPrimary id);

        Task<IEnumerable<TModel>> GetAllAsync();

        Task<IEnumerable<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

        Task<TModel> AddAsync(TModel model);

        Task<IEnumerable<TModel>> AddAsync(IEnumerable<TModel> models);

        Task<TModel> UpdateAsync(TModel model);

        Task<IEnumerable<TModel>> UpdateAsync(IEnumerable<TModel> models);
        Task DeleteByIdAsync(TPrimary id);
        Task<TModel> DeleteAsync(TModel model);

        Task<IEnumerable<TModel>> DeleteAsync(IEnumerable<TModel> models);

        Task<IEnumerable<TModel>> GetWithPredicateAsync(Expression<Func<TDocument, bool>> predicate);

        Task<IEnumerable<TModel>> GetAsync(
            Expression<Func<TDocument, bool>>? filter = null,
            Func<IQueryable<TDocument>, IOrderedQueryable<TDocument>>? orderBy = null);

        Task<TModel?> GetUniqueAsync(
            Expression<Func<TDocument, bool>>? filter = null,
            Func<IQueryable<TDocument>, IOrderedQueryable<TDocument>>? orderBy = null);
        Task<IEnumerable<TModel>> FindByIdsAsync(IEnumerable<TPrimary> ids);

        Task<long> CountAsync(Expression<Func<TDocument, bool>> predicate);

        Task<bool> ExistsAsync(TPrimary id);
    }
}
