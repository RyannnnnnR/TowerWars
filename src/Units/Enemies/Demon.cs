using System;
namespace MyGame
{
	public class Demon : Unit
	{
		public Demon () : base("monster4.png", "monsterwalking.txt", -0.4f)
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
			return "demon";
		}
	}
}
