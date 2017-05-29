using System;
using SwinGameSDK;

namespace MyGame
{
	///<summary>
	///This controls all the details pertaining to a tower(i.e x,y coordinates and health)
	///</summary
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
	/// <summary>
    /// The health of the tower
    /// </summary>
    ///<value>The Health property gets/sets the health of the tower</value>
		public float Health {

			get {return health;}
			set {health = value; }
		}
		/// <summary>
		/// The X coordinate of the tower
		/// </summary>
		///<value>The X property gets/sets the X coordinate</value>
		public int X {

			get { return x; }
			set { x = value; }
		}
		/// <summary>
		/// The Y coordinate of the tower
		/// </summary>
		///<value>The Y property gets/sets the Y coordinate</value>
		public int Y {

			get { return y; }
			set { y = value; }
		}
	}
}
