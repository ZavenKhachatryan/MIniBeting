using Microsoft.AspNetCore.Mvc;
using Entity.DAL.LoginModels;
using Entity.DAL.LoginLogic;

namespace Beting.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignUpController : ControllerBase
	{
		private static readonly AddLoginWithUserDataToLoginDb _addToLoginDb;
		static SignUpController()
		{
			_addToLoginDb = new AddLoginWithUserDataToLoginDb();
		}

		[HttpPost("AddUserData")]
		public ActionResult AddUserData(LoginUserData userData)
		{
			_addToLoginDb.UserData = userData;

			return Ok("User Data Inserted");
		}

		[HttpPost("AddUser")]
		public ActionResult AddUser(LoginUser user) 
		{
			_addToLoginDb.User = user;

			return Ok("User Inserted");
		}

		[HttpPost("AddLogin")]
		public ActionResult AddLogin(Login login) 
		{
			_addToLoginDb.Login = login;

			if (_addToLoginDb.AddUserData())
			{
				return Ok("Login Added with user data");
			}

			return Ok("Login don't Added (");
		}
	}
}
