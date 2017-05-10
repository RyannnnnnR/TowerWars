using System;
namespace MyGame
{
	public class Ghost : Unit
	{
		public Ghost () : base("monster4.png", "monsterwalking.txt")
		{
		}

		public override string getName ()
		{
			return "ghost";
		}
	}
}
