using Microsoft.EntityFrameworkCore;
using Entity.DAL.EntityConfigurations.BettingConfigurations;
using Microsoft.Extensions.Configuration;
using System;

namespace Entity.DAL.DB
{
	public partial class BettingDbContext : DbContext
    {
        public BettingDbContext()
        {
        }

        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("BetingDb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new UserBetLaLigaConfiguration());
            modelBuilder.ApplyConfiguration(new UserGameLaLigaConfiguration());
            modelBuilder.ApplyConfiguration(new UserBetingConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
