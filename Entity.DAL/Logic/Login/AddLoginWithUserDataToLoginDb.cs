using Entity.DAL.DB;
using Entity.DAL.LoginModels;

namespace Entity.DAL.LoginLogic
{
	public class AddLoginWithUserDataToLoginDb
	{
		public LoginUserData UserData { get; set; }
		public LoginUser User { get; set; }
		public Login Login { get; set; }

		public bool AddUserData()
		{
			using (var db = new LoginDbContext())
			{
				db.UserData.Add(UserData);
				db.SaveChanges();

				var usr = new LoginUser
				{
					UserDataId = UserData.Id,
					FirstName = User.FirstName,
					LastName = User.LastName,
				};
				db.Users.Add(usr);
				db.SaveChanges();

				var lgn = new Login
				{
					UserId = usr.Id,
					UsrLogin = Login.UsrLogin,
					Upassword = Login.Upassword
				};

				db.Logins.Add(lgn);
				db.SaveChanges();
			}

			using (var db = new BettingDbContext())
			{
				var usrdt = new BettingModels.UserData
				{
					UserLogin = Login.UsrLogin,
					UserName = User.FirstName,
					Balance = 0
				};
				db.UserData.Add(usrdt);
				db.SaveChanges();
			}

			return true;
		}
	}
}
