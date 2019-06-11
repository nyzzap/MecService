using Microsoft.EntityFrameworkCore;
using GenAPI.Domain.Entities;

namespace GenAPI.Migrations
{

    public class GenContextMigration : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Debtor> Debtors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);                
                entity.Property(e => e.Password).HasColumnType("nvarchar(100)").HasMaxLength(50);
                entity.Property(e => e.Username).HasColumnType("nvarchar(100)").HasMaxLength(255);
                entity.Property(e => e.Email).HasColumnType("nvarchar(100)").HasMaxLength(255);
            });

            //Debtor
            modelBuilder.Entity<Debtor>().ToTable("Debtor","dbo");
            modelBuilder.Entity<Debtor>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnType("nvarchar(100)").HasMaxLength(255);
                entity.Property(e => e.BirthDate).HasColumnType("DATETIME");
                entity.Property(e => e.DebtToDue).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.DueDebt).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.PositiveBalance).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.Frontnames).HasColumnType("nvarchar(100)").HasMaxLength(85);
                entity.Property(e => e.Surnames).HasColumnType("nvarchar(100)").HasMaxLength(85);
                entity.Property(e => e.IDCard).HasColumnType("nvarchar(100)").HasMaxLength(255);
            });
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Initial Catalog=Gen;Data Source=.\SQLEXPRESS;Database=Gen;User ID=sa;Password=Emerix01;Persist Security Info=True;");
        }
    }
}
