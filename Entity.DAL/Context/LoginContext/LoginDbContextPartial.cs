using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.DAL.LoginModels;

#nullable disable

namespace Entity.DAL.DB
{
    public partial class LoginDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
        public virtual DbSet<LoginUser> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<LoginUserData> UserData { get; set; }
    }
}
