using System;
namespace MyGame
{
	/// <summary>
	/// Defines lizard enemy character
	/// </summary>
	public class Lizard : Unit
	{
		public Lizard () : base("lizardBmp", "walkingScrpt", -0.4f, 8, true)
		{
		}

		public override string getName ()
		{
			return "lizard";
		}
	}
}
