namespace GenAPI.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                                    string includeProperties);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IEnumerable<TEntity>> GetAsnyc(Expression<Func<TEntity, bool>> filter,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                                string includeProperties);

        TEntity GetByID(TKey id);
        void Insert(ref TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entityToDelete);
        bool Save();
    }
}
