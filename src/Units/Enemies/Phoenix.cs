using System;
namespace MyGame
{
	public class Phoenix : Unit
	{
		public Phoenix () : base ("monster_phoenix.png", "phoenixflying.txt", -0.5f)
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
			return "phoenix";
		}
	}
}
