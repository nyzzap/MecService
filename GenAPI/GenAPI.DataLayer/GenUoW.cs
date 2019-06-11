namespace GenAPI.DataLayer
{
    using System;
    using System.Threading.Tasks;
    using GenAPI.DataLayer.Abstract;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    public class GenUoW : IGenUoW
    {
        private bool _disposed;
        private DbContext context;
        public IDbContextTransaction Transaction { get; private set; }
        public GenUoW(GenContext conn)
        {
            if (conn == null)
                throw new ArgumentNullException(nameof(conn));
            var MasterDbContext = conn;
            this.context = conn;
            this.context.Database.Migrate();
        }

        public DbContext DatabaseContext => this.context;

        public void Save() => context.SaveChanges();
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();
            this.disposed = true;
        }
        public void Dispose() =>  Dispose(true);
        ~GenUoW() => Dispose(false);

        public IDbContextTransaction BeginTransaction()
        {
            this.Transaction = DatabaseContext.Database.BeginTransaction();
            return this.Transaction;
        }
        public void RollBack()
        {
            Transaction?.Rollback();
            Dispose();
        }

        public int Commit()
        {
            int resultSave = 0;

            if (DatabaseContext.ChangeTracker.HasChanges())
            {
                resultSave = DatabaseContext.SaveChanges();
                Transaction?.Commit();
            }
            return resultSave;
        }
        public async Task CommitAsync() =>
             await DatabaseContext.SaveChangesAsync();
    }
}
