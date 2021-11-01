using Entity.DAL.LoginModels;
using Entity.DAL.LoginLogic;
using Microsoft.AspNetCore.Mvc;
using Beting.Controllers.UserControllers;
using Entity.DAL.BettingModels;

namespace Beting.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private static readonly LoginChecker _checkLogin;

		static SignInController()
		{
			_checkLogin = new LoginChecker();
		}

		[HttpPost("LogIn")]
		public ActionResult LogIn(Login login)
		{
			if (_checkLogin.IsLoggedIn(login))
			{
				UserBetingController.AuthorizedUserData = new UserData();
				UserBetingController.AuthorizedUserData.UserLogin = login.UsrLogin;

				return Ok("Signed In");
			}

			return RedirectToAction();
		}
	}
}
