using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TeamManager
	{
		public List<Unit> heros;
		public List<Unit> enemies;
		public TeamManager ()
		{
			heros = new List<Unit> ();
			enemies = new List<Unit> ();
		}
		public void AddHero (Unit hero) {
			heros.Add (hero);
		}
		public void AddEnemy (Unit enemy)
		{
			enemies.Add (enemy);
		}
	}
}
