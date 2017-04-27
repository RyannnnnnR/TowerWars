using System;
namespace MyGame
{
	public class Ranger :Unit, RangedAttacker
	{
		public Ranger ()
		{
		}

		public int dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public void attack ()
		{
			throw new NotImplementedException ();
		}

		public override void move ()
		{
			throw new NotImplementedException ();
		}
	}
}
