﻿using Microsoft.EntityFrameworkCore;
using Entity.Domain;

namespace Entity.Data
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<SamuraiBattle> SamuraiBattles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      modelBuilder.Entity<SamuraiBattle>()
        .HasKey(s => new {s.BattleId, s.SamuraiId});

      //modelBuilder.Entity<Samurai>()
      //  .Property(s => s.SecretIdentity).IsRequired();
      base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
        //"Server = (localdb)\\mssqllocaldb; Database = SamuraiRelatedData; Trusted_Connection = True; ",
        "Server = PSL-SWD8; Database = SamuraiData; User Id = sa; Password = persol123; MultipleActiveResultSets=true",
         options =>options.MaxBatchSize(30));

       optionsBuilder.EnableSensitiveDataLogging();
    }
  }
}