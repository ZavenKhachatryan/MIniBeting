using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.DAL.BettingModels;

#nullable disable

namespace Entity.DAL.DB
{
    public partial class BettingDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) { }

        public virtual DbSet<UserBetLaLiga> BetLaLigas { get; set; }
        public virtual DbSet<UserGameLaLiga> GameLaLigas { get; set; }
        public virtual DbSet<UserBeting> UserBetings { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
    }
}
