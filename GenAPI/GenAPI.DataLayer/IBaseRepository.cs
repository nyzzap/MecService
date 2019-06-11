namespace GenAPI.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy,
                                    string includeProperties);

        Task<IEnumerable<TEntity>> GetAsnyc(Expression<Func<TEntity, bool>> filter,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy,
                                string includeProperties);

        TEntity GetByID(TKey id);
        void Insert(ref TEntity Entity);
        void Delete(TKey id);
        void Delete(TEntity EntityToDelete);
        bool Save();
    }
}
