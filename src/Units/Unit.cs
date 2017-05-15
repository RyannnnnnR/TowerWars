using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Unit
	{
		private int health = 100;
		private int price;
		private Sprite sprite;
		private float movementSpeeed;
		public Unit (string bitmap, string animation, float movementSpeed)
		{
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed (animation));
			SetLocation (Position.SPAWN_X, Position.SPAWN_Y);
			SwinGame.SpriteSetDX (sprite, movementSpeed);
			SwinGame.SpriteSetDY (sprite, 0);
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");//Cause of exception?
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
		public abstract int Dmg { get; set; }
		public int Price { 
			get { return price; }
			set { price = value;}
		}
		public abstract string getName ();
		public void draw () { 
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
		public int Health {
			get {
				return health;
			}
			set { health = value; }
		}
		public Sprite Spirte { get { return sprite; }}

	}

}
