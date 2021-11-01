using Entity.DAL.AdminModels;
using Entity.DAL.Logic.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Beting.Controllers.AdminControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private static readonly AdminBeting _adminBeting;

		static AdminController()
		{
			_adminBeting = new AdminBeting();
		}

		[HttpPost("AddTeam")]
		public bool AddTeam(AdminTeamLaLiga team)
		{
			if (_adminBeting.AddTeam(team))
			{
				return true;
			}

			return false;
		}

		[HttpPost("DeleteTeam")]
		public bool DeleteTeam(AdminTeamLaLiga team)
		{
			if (_adminBeting.RemoveTeam(team))
			{
				return true;
			}

			return false;
		}

		[HttpPost("AddGame")]
		public bool AddGame(AdminGameLaLiga game)
		{
			if (_adminBeting.AddGame(game))
			{
				return true;
			}

			return false;
		}

		[HttpPost("DeleteGame")]
		public bool DeleteGame(AdminGameLaLiga game)
		{
			if (_adminBeting.RemoveGame(game))
			{
				return true;
			}

			return false;
		}

		[HttpPost("AddBet")]
		public bool AddBet(AdminBetLaLiga bet) 
		{
			if (_adminBeting.AddBet(bet))
			{
				return true;
			}

			return false;
		}

		[HttpPost("UpdateBet")]
		public bool UpdateBet(AdminBetLaLiga bet) 
		{
			if (_adminBeting.UpdateBet(bet))
			{
				return true;
			}

			return false;
		}
	}
}
