using System;
namespace MyGame
{
	public class Cactus : Unit
	{
		public Cactus () : base("monster_cacto.png", "cactowalking.txt")
		{
		}

		public override string getName ()
		{
			return "cactus";
		}
	}
}
