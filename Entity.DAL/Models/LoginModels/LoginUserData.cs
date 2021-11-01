using System;
using System.Collections.Generic;

namespace Entity.DAL.LoginModels
{
    public partial class LoginUserData
    {
        public LoginUserData()
        {
            Users = new HashSet<LoginUser>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrnetAddress { get; set; }

        public virtual ICollection<LoginUser> Users { get; set; }
    }
}
