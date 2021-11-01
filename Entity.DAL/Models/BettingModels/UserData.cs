using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.DAL.BettingModels
{
    public partial class UserData
    {
        public UserData()
        {
            UserBetings = new HashSet<UserBeting>();
        }

        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<UserBeting> UserBetings { get; set; }
    }
}
