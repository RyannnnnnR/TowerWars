using System;
namespace MyGame
{
	/// <summary>
	/// Defines phoenix enemy character
	/// </summary>
	public class Phoenix : Unit
	{
		public Phoenix () : base ("phoenixBmp", "walkingScrpt", -0.5f, 10, true)
		{
		}


		public override string getName ()
		{
			return "phoenix";
		}
	}
}
