namespace GenAPI.DataLayer
{
    using Microsoft.EntityFrameworkCore;
    using GenAPI.Domain.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GenContext : DbContext
    {
        public DbSet<User> Users { get; set; }      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnType("varchar").HasMaxLength(255);
                entity.Property(e => e.Password).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Username).HasColumnType("varchar").HasMaxLength(255);
            });
            //Client
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Code).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.FirstName).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.LastName).HasColumnType("varchar").HasMaxLength(50);

                //AddRelationship
                entity.HasMany(s => s.Vehicles)
                      .WithOne(x => x.Client);
            });
            //Vehicle
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Brand).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.Model).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Patent).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Year).HasColumnName("Year");
                
            });
            //MecService
            modelBuilder.Entity<MecService>().ToTable("MecService");
            modelBuilder.Entity<MecService>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(50);
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.Price).HasColumnType("decimal(5,2)");
            });
            //VehicleOrderService
            modelBuilder.Entity<VehicleOrderService>().ToTable("VehicleOrderService");
            modelBuilder.Entity<VehicleOrderService>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.CompletionDate).HasColumnName("CompletionDate");
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(5,2)");

                //AddRelationship MecServices
                entity.HasMany(s => s.MecServices);

                //AddRelationship Vehicle
                entity.HasOne(s => s.Vehicle);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
