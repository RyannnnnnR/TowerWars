using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A class used to store data about each team - heroes and enemies
	/// </summary>
	public class TeamManager
	{
		private List<Unit> heroes;
		private List<Unit> enemies;
		public TeamManager ()
		{
			heroes = new List<Unit> ();
			enemies = new List<Unit> ();
		}
		/// <summary>
		/// Adds a hero to the hero team
		/// </summary>
		/// <param name="hero">A unit</param>
		public void AddHero (Unit hero) {
			heroes.Add (hero);
		}
		/// <summary>
		/// Adds an enemy to the enemy team
		/// </summary>
		/// <param name="enemy">A unit</param>
		public void AddEnemy (Unit enemy)
		{
			enemies.Add (enemy);
		}
		/// <summary>
		/// Clears the teams
		/// </summary>
		public void clearTeams () {
			if (heroes.Count > 0 && enemies.Count > 0) {
				heroes.Clear ();
				enemies.Clear ();
			}
		}
		/// <summary>
		/// Gets all the heroes on the heroes team
		/// </summary>
		/// <value>The heroes list</value>
		public List<Unit> Heroes {
			get {
				return heroes;
			}
		}
		/// <summary>
		/// Gets the enemies on the enemy team
		/// </summary>
		/// <value>The enemies list</value>
		public List<Unit> Enemies {
			get {
				return enemies;
			}
		}
	}
}
