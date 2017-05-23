using System;
using SwinGameSDK;

namespace MyGame
{
	public class Projectile
	{
		private float x;
		private float y;
		private float projectileSpeed;
		private Sprite sprite;

		public Projectile (string bitmap, string animation, float x, float y, float projectileSpeed, Unit unit)
		{
			this.x = x;
			this.y = y;
			this.projectileSpeed = projectileSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed(animation));
			SwinGame.SpriteStartAnimation (sprite, "fireball_cast");
			SwinGame.SpriteSetX (sprite, unit.getX()+10);
			SwinGame.SpriteSetY (sprite, unit.getY());
			SwinGame.SpriteSetDX (sprite, projectileSpeed);
		}
		public float X {
			get {
				return x;
			}
		}
		public void draw ()
		{
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
		public float Y {
			get {
				return y;
			}
		}
	}
}
