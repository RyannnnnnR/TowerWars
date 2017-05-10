using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Unit
	{
		private int health;
		private int price;
		private Sprite sprite;
		public Unit (string bitmap, string animation)
		{
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed (animation));
			SetLocation (Position.SPAWN_X, Position.SPAWN_Y);
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");
		}
		public void SetLocation (float x, float y) {
			SwinGame.SpriteSetX (sprite, x);
			SwinGame.SpriteSetY (sprite, y);
		}
		public void move () {
			draw ();
		}
		public int Price { 
			get { return price; }
			set { price = value;}
		}
		public abstract string getName ();
		public void draw () { 
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}

		public Sprite Spirte { get { return sprite; }}

	}

}
