using GenAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GenAPI.DataLayer.Abstract;
using GenAPI.DataLayer;
using GenAPI.DAO.Repository.Abstract;

namespace GenAPI.DAO.Repository.Concrete
{

    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        public UserRepository(IGenUoW unitOfWork) : base(unitOfWork)
        {
            _dbSet = unitOfWork.DatabaseContext.Set<User>();
        }
    }
}