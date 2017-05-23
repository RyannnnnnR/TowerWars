using System;
namespace MyGame
{
	public class Tree : Unit
	{
		public Tree () : base("treeBmp", "walkingScrpt", -0.5f, 5, true)
		{
		}


		public override string getName ()
		{
			return "tree";
		}
	}
}
