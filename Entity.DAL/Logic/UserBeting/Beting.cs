using System;
using System.Collections.Generic;
using System.Linq;
using Entity.DAL.AdminModels;
using Entity.DAL.BettingModels;
using Entity.DAL.DB;

namespace Entity.DAL.Logic.UserBetingLogic
{
	public class Beting
	{
		// UserData-n controlleric stacac datan a , vory ira mej pahum a konkret useri loginy
		public bool UpdateBalance(UserData userData)
		{
			using (var db = new BettingDbContext())
			{
				//TODO: Some Logic
				var usrData = db.UserData.Where(ud => ud.UserLogin == userData.UserLogin).FirstOrDefault();

				if (usrData != null)
				{
					usrData.Balance += userData.Balance;
					db.UserData.Update(usrData);
					db.SaveChanges();

					return true;
				}
			}
			return false;
		}

		public bool AddGameForBet(BetDetailsModel model, UserData data)
		{
			using (var userDb = new BettingDbContext())
			{
				using (var adminDb = new AdminDbContext())
				{
					var userData = userDb.UserData.Where(d => d.UserLogin == data.UserLogin).FirstOrDefault();

					if (userData == null)
					{
						throw new ArgumentNullException("User Data is NUll");
					}

					decimal userBalance = 0;
					CheckUserBalance(userData, model, out userBalance);

					//var userGame = new UserGameLaLiga();
					var adminGame = SelectGameFromAdminAndAddUserGame(adminDb, userDb, model, out UserGameLaLiga userGame);

					var adminBet = SelectAdminBet(adminDb, adminGame);

					decimal totalCoefficient = 0;
					var userBet = AddUserBet(userDb, model, adminBet, userGame, out totalCoefficient);

					AddUserBeting(userDb, model, userData, userBet, totalCoefficient);

					userData.Balance = userBalance;
					userDb.UserData.Update(userData);
					userDb.SaveChanges();

					return true;
				}
			}
		}

		private void CheckUserBalance(UserData userData, BetDetailsModel model, out decimal userBalance)
		{
			if (userData == null)
			{
				throw new ArgumentNullException("User Data is null");
			}

			userBalance = userData.Balance - model.BetPrice;

			if (userBalance <= 0)
			{
				throw new Exception("Insufficient Funds");
			}
		}

		/// <summary>
		/// Adminic vercrac xaxy` tmeri anunnerov , insert em anum useris gameLaLiga Tableum
		/// </summary>
		/// <param name="model"></param>
		/// <param name="userGame"></param>
		/// <returns></returns>
		private AdminGameLaLiga SelectGameFromAdminAndAddUserGame(AdminDbContext adminDb, BettingDbContext userDb, BetDetailsModel model, out UserGameLaLiga userGame)
		{
			var adminGame = adminDb.AdminGameLaLigas.Where(g => g.Id == model.GameId).FirstOrDefault();

			if (adminGame == null)
			{
				throw new ArgumentNullException("Admin Game is null");
			}

			var team1 = from g in adminDb.AdminGameLaLigas
						join t in adminDb.AdminTeamLaLigas
						on g.Team1Id equals t.Id
						select g.Team1;

			var team2 = from g in adminDb.AdminGameLaLigas
						join t in adminDb.AdminTeamLaLigas
						on g.Team2Id equals t.Id
						select g.Team2;

			if (team1 == null && team2 == null)
			{
				throw new ArgumentNullException("Team Names");
			}

			var t1Name = team1.FirstOrDefault();
			var t2Name = team2.FirstOrDefault();

			userGame = new UserGameLaLiga
			{
				Team1 = t1Name.Team,
				Team2 = t2Name.Team,
				GameDate = adminGame.GameDate
			};

			userDb.GameLaLigas.Add(userGame);
			userDb.SaveChanges();

			return adminGame;
		}

		/// <summary>
		/// yst im yntrac xaxi adminic vercnum em et xaxi gorcakicnery
		/// </summary>
		/// <returns></returns>
		private AdminBetLaLiga SelectAdminBet(AdminDbContext adminDb, AdminGameLaLiga adminGame)
		{
			var adminBet = adminDb.AdminBetLaLigas.Where(b => b.GameId == adminGame.Id).FirstOrDefault();

			if (adminBet == null)
			{
				throw new ArgumentNullException("Admin Bet is null");
			}

			return adminBet;
		}

		/// <summary>
		/// Stugum em usery inchi vraya stavka arel u dranc hamapatasxan gorcakicnery avelacnum em useri betLaliga tableum
		/// </summary>
		/// <returns></returns>
		private UserBetLaLiga AddUserBet(BettingDbContext userDb, BetDetailsModel model, AdminBetLaLiga adminBet, UserGameLaLiga userGame, out decimal totalCoefficient)
		{
			var userBet = new UserBetLaLiga();

			userBet.GameId = userGame.Id;

			totalCoefficient = 0;
			if (model.T1win)
			{
				userBet.T1win = adminBet.T1win;
				totalCoefficient += (decimal)userBet.T1win;
			}
			else
			if (model.T2win)
			{
				userBet.T2win = adminBet.T2win;
				totalCoefficient += (decimal)userBet.T2win;
			}
			else
			if (model.Draw)
			{
				userBet.Draw = adminBet.Draw;
				totalCoefficient += (decimal)userBet.Draw;
			}

			if (model.T1yellowCardTwoAndMore)
			{
				userBet.T1yellowCardTwoAndMore = adminBet.T1yellowCardTwoAndMore;
				totalCoefficient += (decimal)userBet.T1yellowCardTwoAndMore;
			}
			else
			if (model.T2yellowCardTwoAndMore)
			{
				userBet.T2yellowCardTwoAndMore = adminBet.T2yellowCardTwoAndMore;
				totalCoefficient += (decimal)userBet.T2yellowCardTwoAndMore;
			}

			userDb.BetLaLigas.Add(userBet);
			userDb.SaveChanges();

			return userBet;
		}

		private void AddUserBeting(BettingDbContext userDb, BetDetailsModel model, UserData userData, UserBetLaLiga userBet, decimal totalCoefficient)
		{
			var userBeting = new UserBeting()
			{
				UserDataId = userData.Id,
				BetId = userBet.Id,
				BetPrice = model.BetPrice,
				TotalCoefficient = totalCoefficient
			};

			userDb.UserBetings.Add(userBeting);
			userDb.SaveChanges();
		}

		public bool IsWin(BetDetailsModel model, UserData data)
		{
			using (var db = new BettingDbContext())
			{
				var games = db.GameLaLigas
					.Where(g => g.Team1 == model.Team1 && g.Team2 == model.Team2 && g.GameDate == model.GameDate);

				if (games == null)
				{
					throw new ArgumentNullException("Games is null");
				}

				List<int> gameIds = new List<int>();
				foreach (var item in games)
				{
					gameIds.Add(item.Id);
				}

				foreach (var gameId in gameIds)
				{
					var bet = db.BetLaLigas.Where(b => b.GameId == gameId).FirstOrDefault();
					if (bet == null)
					{
						return false;
					}

					var userData = db.UserData.Where(d => d.UserLogin == data.UserLogin).FirstOrDefault();
					if (userData == null)
					{
						return false;
					}

					var userBeting = db.UserBetings.Where(b => b.UserDataId == userData.Id && b.BetId == bet.Id).FirstOrDefault();
					if (userBeting == null)
					{
						continue;
					}

					var addBalance = userBeting.TotalCoefficient * userBeting.BetPrice;

					if (bet.T1yellowCardTwoAndMore == null && bet.T2yellowCardTwoAndMore == null)
					{
						if (model.T1win && bet.T1win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.T2win && bet.T2win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.Draw && bet.Draw != null)
						{
							userData.Balance += addBalance;
						}
					}
					if (model.T1yellowCardTwoAndMore && bet.T1yellowCardTwoAndMore != null)
					{
						if (model.T1win && bet.T1win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.T2win && bet.T2win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.Draw && bet.Draw != null)
						{
							userData.Balance += addBalance;
						}
					}
					if (model.T2yellowCardTwoAndMore && bet.T2yellowCardTwoAndMore != null)
					{
						if (model.T1win && bet.T1win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.T2win && bet.T2win != null)
						{
							userData.Balance += addBalance;
						}
						if (model.Draw && bet.Draw != null)
						{
							userData.Balance += addBalance;
						}
					}
					else
					{
						continue;
					}

					if (true)
					{
						db.UserData.Update(userData);
						db.SaveChanges();

						return true;
					}
				}

				return false;
			}
		}
	}
}
