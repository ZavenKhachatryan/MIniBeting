using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.DAL.AdminModels;
using Entity.DAL.EntityConfigurations.AdminConfigurations;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Entity.DAL.DB
{
	public partial class AdminDbContext : DbContext
	{
		public AdminDbContext()
		{
		}

		public AdminDbContext(DbContextOptions<AdminDbContext> options)
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

				optionsBuilder.UseSqlServer(configuration.GetConnectionString("AdminDb"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

			modelBuilder.ApplyConfiguration(new AdminBetLaLigaConfiguration());
			modelBuilder.ApplyConfiguration(new AdminGameLaLigaConfiguration());
			modelBuilder.ApplyConfiguration(new AdminTeamLaLigaConfiguration());

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
