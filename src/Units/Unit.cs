using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Unit
	{
		private float health = 100.00f;
		private Sprite sprite;
		private float movementSpeeed = 0.0f;
		private float dmg;
		public Unit (string bitmap, string animation, float movementSpeed, float dmg, bool enemy)
		{
			this.movementSpeeed = movementSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed(animation));
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");

			if (enemy) {
				SwinGame.SpriteSetX (sprite, Position.ENEMY_SPAWN_X);
				SwinGame.SpriteSetY (sprite, Position.ENEMY_SPAWN_Y);
			} else {
				SwinGame.SpriteSetX (sprite, Position.HERO_SPAWN_X);
				SwinGame.SpriteSetY (sprite, Position.HERO_SPAWN_Y);
			}

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
		public float Dmg { get { return dmg;} set { dmg = value;} }//Delete dmg from child classes
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
