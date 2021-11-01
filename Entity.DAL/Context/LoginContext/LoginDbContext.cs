using Microsoft.EntityFrameworkCore;
using Entity.DAL.EntityConfigurations.LoginConfigurations;
using Microsoft.Extensions.Configuration;
using System;

#nullable disable

namespace Entity.DAL.DB
{
	public partial class LoginDbContext : DbContext
    {
        public LoginDbContext()
        {
        }

        public LoginDbContext(DbContextOptions<LoginDbContext> options)
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

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("LoginDb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new LoginConfiguration());
            modelBuilder.ApplyConfiguration(new LoginUserConfiguration());
            modelBuilder.ApplyConfiguration(new LoginUserDataConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
