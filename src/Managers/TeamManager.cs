using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TeamManager
	{
		private List<Sprite> heros;
		private List<Sprite> enemies;
		public TeamManager ()
		{
			heros = new List<Sprite> ();
			enemies = new List<Sprite> ();
		}
	}
}
