using System;
namespace MyGame
{
	public class Tree : Unit
	{
		public Tree () : base("monster_treant.png", "cactowalking.png")
		{
		}

		public override string getName ()
		{
			return "tree";
		}
	}
}
