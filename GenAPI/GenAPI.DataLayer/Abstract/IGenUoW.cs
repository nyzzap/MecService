namespace GenAPI.DataLayer.Abstract
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading.Tasks;
    public interface IGenUoW
    {
        DbContext DatabaseContext { get; }
        IDbContextTransaction BeginTransaction();
        void RollBack();
        int Commit();
        Task CommitAsync();
        void Save();
    }
}
