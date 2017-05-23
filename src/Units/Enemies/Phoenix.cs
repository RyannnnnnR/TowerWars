using System;
namespace MyGame
{
	public class Phoenix : Unit
	{
		public Phoenix () : base ("phoenixBmp", "walkingScrpt", -0.5f, 5, true)
		{
		}


		public override string getName ()
		{
			return "phoenix";
		}
	}
}
