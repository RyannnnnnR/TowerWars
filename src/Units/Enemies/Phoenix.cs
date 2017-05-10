using System;
namespace MyGame
{
	public class Phoenix : Unit
	{
		public Phoenix () : base("monster_phoenix.png", "phoenixflying.txt")
		{
		}

		public override string getName ()
		{
			return "phoenix";
		}
	}
}
