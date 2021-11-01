using System.Linq;
using Entity.DAL.AdminModels;
using Entity.DAL.DB;

namespace Entity.DAL.Logic.Admin
{
	public class AdminBeting
	{
		public bool AddTeam(AdminTeamLaLiga team)
		{
			using (var db = new AdminDbContext())
			{
				db.AdminTeamLaLigas.Add(team);
				db.SaveChanges();
			}
			return true;
		}

		public bool RemoveTeam(AdminTeamLaLiga team)
		{
			using (var db = new AdminDbContext())
			{
				var tm = db.AdminTeamLaLigas.Where(t => team.Id == t.Id).FirstOrDefault();
				if (tm != null)
				{
					db.AdminTeamLaLigas.Remove(tm);
					db.SaveChanges();

					return true;
				}
			}

			return false;
		}

		public bool AddGame(AdminGameLaLiga game)
		{
			using (var db = new AdminDbContext())
			{
				db.AdminGameLaLigas.Add(game);
				db.SaveChanges();
			}
			return true;
		}

		public bool RemoveGame(AdminGameLaLiga game)
		{
			using (var db = new AdminDbContext())
			{
				var gm = db.AdminGameLaLigas.Where(g => g.Id == game.Id).FirstOrDefault();

				if (gm == null)
				{
					return false;
				}

				if (!RemoveBet(db, game))
				{
					return false;
				}

				db.AdminGameLaLigas.Remove(gm);
				db.SaveChanges();
			}
			return true;
		}
		private bool RemoveBet(AdminDbContext db, AdminGameLaLiga game)
		{
			var bt = db.AdminBetLaLigas.Where(b => b.GameId == game.Id).FirstOrDefault();

			if (bt != null)
			{
				db.AdminBetLaLigas.Remove(bt);
				db.SaveChanges();

				return true;
			}

			return false;
		}

		public bool AddBet(AdminBetLaLiga bet)
		{
			using (var db = new AdminDbContext())
			{
				db.AdminBetLaLigas.Add(bet);
				db.SaveChanges();
			}

			return true;
		}

		public bool UpdateBet(AdminBetLaLiga bet)
		{
			using (var db = new AdminDbContext())
			{
				var bt = db.AdminBetLaLigas.Where(b => b.Id == bet.Id).FirstOrDefault();

				if (bt != null)
				{
					if (bet.T1win != default)
					{
						bt.T1win = bet.T1win;
					}
					if (bet.T2win != default)
					{
						bt.T2win = bet.T2win;
					}
					if (bet.Draw != default)
					{
						bt.Draw = bet.Draw;
					}
					if (bet.T1yellowCardTwoAndMore != default)
					{
						bt.T1yellowCardTwoAndMore = bet.T1yellowCardTwoAndMore;
					}
					if (bet.T2yellowCardTwoAndMore != default)
					{
						bt.T2yellowCardTwoAndMore = bet.T2yellowCardTwoAndMore;
					}

					db.AdminBetLaLigas.Update(bt);
					db.SaveChanges();

					return true;
				}
			}

			return false;
		}

	}
}
