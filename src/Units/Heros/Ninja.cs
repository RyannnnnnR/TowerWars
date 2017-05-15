using System;
namespace MyGame
{
	//Ranged or physical????
	public class Ninja : Unit
	{
	public Ninja () :base("ninjaBmp", "ninjaRunninScrpt", 0.5f)
		{
		}

		public override int Dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public override string getName ()
		{
			return "ninja";
		}
	}
}
