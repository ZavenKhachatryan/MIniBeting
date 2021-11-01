using System.Linq;
using Entity.DAL.DB;
using Entity.DAL.LoginModels;

namespace Entity.DAL.LoginLogic
{
	public class LoginChecker
	{
		public bool IsLoggedIn(Login login) 
		{
			using (var db = new LoginDbContext())
			{
				var lgn = db.Logins.Where(l => l.UsrLogin == login.UsrLogin && l.Upassword == login.Upassword).FirstOrDefault();

				if (lgn == null)
				{
					return false;
				}

				if (lgn.Upassword == login.Upassword && lgn.UsrLogin == login.UsrLogin)
				{
					return true;
				}

				return false;
			}
		}
	}
}
