using Microsoft.AspNetCore.Mvc;
using Entity.DAL.BettingModels;

namespace Beting.Controllers.UserControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserBetingController : ControllerBase
	{
		public  static UserData AuthorizedUserData { get; set; }
		private static readonly Entity.DAL.Logic.UserBetingLogic.Beting _beting;

		static UserBetingController()
		{
			_beting = new Entity.DAL.Logic.UserBetingLogic.Beting();
		}

		[HttpPost("UpdateBalance")]
		public bool UpdateBalance(UserData userData)
		{
			//TODO: some Logic
			AuthorizedUserData.Balance = userData.Balance;

			if (_beting.UpdateBalance(AuthorizedUserData))
			{
				return true;
			}

			return false;
		}

		[HttpPost("AddGameForBet")]
		public bool AddGameForBet(BetDetailsModel model)
		{
			if (_beting.AddGameForBet(model, AuthorizedUserData))
			{
				return true;
			}

			return false;
		}

		[HttpGet("BetingResult")]
		public ActionResult BetingResult(BetDetailsModel model) 
		{
			if (_beting.IsWin(model, AuthorizedUserData))
			{
				return Ok("You Win !!!");
			}

			return Ok("You Lose (");
		}
	}
}
