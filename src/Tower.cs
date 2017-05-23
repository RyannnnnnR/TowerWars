using System;
using SwinGameSDK;

namespace MyGame
{
	public class Tower
	{
		private float health = 300.00f;
		private int x;
		private int y;
		public Tower (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public float Health {

			get {return health;}
			set {health = value; }
		}
		public int X {

			get { return x; }
			set { x = value; }
		}
		public int Y {

			get { return y; }
			set { y = value; }
		}
	}
}
