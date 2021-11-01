using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.DAL.LoginModels
{
    public partial class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UsrLogin { get; set; }
        public string Upassword { get; set; }

        public virtual LoginUser User { get; set; }


    }
}
