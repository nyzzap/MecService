namespace GenAPI.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using GenAPI.DataLayer.Abstract;
    using Microsoft.EntityFrameworkCore;
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        internal DbSet<TEntity> _dbSet;
        public DbSet<TEntity> DbSet { get { return _dbSet; } }
        private static IGenUoW _unitOfWork;

        public BaseRepository(IGenUoW genUoW)
        {
            if (genUoW == null)
                throw new ArgumentNullException(nameof(genUoW), @"Unit of work cannot be null");

            this._dbSet = genUoW.DatabaseContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public virtual TEntity GetByID(TKey id) => _dbSet.Find(id);

        public virtual void Insert(ref TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public bool Save()
        {
            return (_unitOfWork.Commit() > 0);
        }
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);
            if (OrderBy != null)
                query = OrderBy(query);

            return query;
        }
        public async Task<IEnumerable<TEntity>> GetAsnyc(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }
    }
}
