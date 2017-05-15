using System;
namespace MyGame
{
	public class Tree : Unit
	{
		public Tree () : base("monster_treant.png", "cactowalking.png", -0.5f)
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
			return "tree";
		}
	}
}
