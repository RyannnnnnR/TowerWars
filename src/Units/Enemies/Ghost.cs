using System;
namespace MyGame
{
	public class Ghost : Unit
	{
		public Ghost () : base ("monster4.png", "monsterwalking.txt", -0.4f)
		{
		}

		public override float Dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public override string getName ()
		{
			return "ghost";
		}
	}
}
