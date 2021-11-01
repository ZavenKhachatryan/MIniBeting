using System.Collections.Generic;

namespace Entity.DAL.LoginModels
{
    public partial class LoginUser
    {
        public LoginUser()
        {
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public int UserDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual LoginUserData UserData { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
