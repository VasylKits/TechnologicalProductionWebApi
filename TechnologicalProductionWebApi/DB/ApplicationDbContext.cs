using Microsoft.EntityFrameworkCore;
using TechnologicalProductionWebApi.Models;

namespace TechnologicalProductionWebApi.DB;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<ProductionBuilding> ProductionBuildings { get; set; }
    public DbSet<TypeOfEquipment> TypeOfEquipments { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductionBuilding>()
            .HasData(new ProductionBuilding { Id = 1, Name = "Building 1", Square = 100, FreeSquare = 40 },
            new ProductionBuilding { Id = 2, Name = "Building 2", Square = 125, FreeSquare = 125 },
            new ProductionBuilding { Id = 3, Name = "Building 3", Square = 88, FreeSquare = 88 },
            new ProductionBuilding { Id = 4, Name = "Building 4", Square = 200, FreeSquare = 200 },
            new ProductionBuilding { Id = 5, Name = "Building 5", Square = 165, FreeSquare = 165 },
            new ProductionBuilding { Id = 6, Name = "Building 6", Square = 346, FreeSquare = 166 });

        modelBuilder.Entity<TypeOfEquipment>()
            .HasData(new TypeOfEquipment { Id = 1, Name = "Type 1", Square = 10 },
            new TypeOfEquipment { Id = 2, Name = "Type 2", Square = 25 },
            new TypeOfEquipment { Id = 3, Name = "Type 3", Square = 18 },
            new TypeOfEquipment { Id = 4, Name = "Type 4", Square = 37 },
            new TypeOfEquipment { Id = 5, Name = "Type 5", Square = 60 },
            new TypeOfEquipment { Id = 6, Name = "Type 6", Square = 5 });

        modelBuilder.Entity<Contract>()
            .HasKey(c => new { c.TypeId, c.BuildingId });
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.ProductionBuilding)
            .WithMany(b => b.Contracts)
            .HasForeignKey(c => c.BuildingId);
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.TypeOfEquipment)
            .WithMany(e => e.Contracts)
            .HasForeignKey(c => c.TypeId);
        modelBuilder.Entity<Contract>()
            .HasData(new Contract { Name = "Contract15", BuildingId = 1, TypeId = 5, Count = 1 },
            new Contract { Name = "Contract65", BuildingId = 6, TypeId = 5, Count = 3 });
    }
}