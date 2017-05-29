using System;
namespace MyGame
{
	/// <summary>
	/// Defines tree enemy character
	/// </summary>
	public class Tree : Unit
	{
		public Tree () : base("treeBmp", "walkingScrpt", -0.5f, 9, true)
		{
		}


		public override string getName ()
		{
			return "tree";
		}
	}
}
