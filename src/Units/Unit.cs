using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Unit
	{
		private float health = 100.00f;
		private int price;
		private Sprite sprite;
		private float movementSpeeed;
		private float dmg;
		public Unit (string bitmap, string animation, float movementSpeed, float dmg)
		{
			this.movementSpeeed = movementSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed (animation));
			SetLocation (Position.SPAWN_X, Position.SPAWN_Y);
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");
			SwinGame.SpriteSetDX (sprite, movementSpeed);
			this.dmg = dmg;
		}
		public void SetLocation (float x, float y) {
			SwinGame.SpriteSetX (sprite, x);
			SwinGame.SpriteSetY (sprite, y);
		}
		public float getX () {
			return SwinGame.SpriteX (sprite);
		}
		public float getY ()
		{
			return SwinGame.SpriteY (sprite);
		}
		public void move () {
			draw ();
		}
		public float Dmg { get { return dmg;} set { dmg = value;} }//Delete dmg from child classes
		public int Price { 
			get { return price; }
			set { price = value;}
		}
		public abstract string getName ();
		public void draw () { 
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
		public float Health {
			get {
				return health;
			}
			set { health = value; }
		}
		public Sprite Spirte { get { return sprite; }}

	}

}
