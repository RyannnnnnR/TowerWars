using System;
using SwinGameSDK;

namespace MyGame
{
	public class Projectile
	{
		private float projectileSpeed;
		private Sprite sprite;
		private Unit unit;
		/// <summary>
		/// Creates skeleton for projectiles (i.e Animation, projectile speed, which unit it belongs to.)
		/// </summary>
		/// <param name="bitmap">Image for the projectile</param>
		/// <param name="animation">The animation script associated.</param>
		/// <param name="projectileSpeed">How fast the projectile fires.</param>
		/// <param name="unit">Unit.</param>
		public Projectile (string bitmap, string animation, float projectileSpeed, Unit unit)
		{
			this.unit = unit;
			this.projectileSpeed = projectileSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed(animation));
			SwinGame.SpriteStartAnimation (sprite, "fireball_cast");
			SwinGame.SpriteSetX (sprite, unit.getX()+10);
			SwinGame.SpriteSetY (sprite, unit.getY());
			SwinGame.SpriteSetDX (sprite, projectileSpeed);
		}
		/// <summary>
		/// A Constructor without the animation details
		/// </summary>
		public Projectile (string bitmap, float projectileSpeed, Unit unit) { 

			this.unit = unit;
			this.projectileSpeed = projectileSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap));
			SwinGame.SpriteSetX (sprite, unit.getX()+10);
			SwinGame.SpriteSetY (sprite, unit.getY());
			SwinGame.SpriteSetDX (sprite, projectileSpeed);
		}
		/// <summary>
		/// Gets the projectiles X position
		/// </summary>
		/// <value>The x value</value>
		public float X {
			get {
				return SwinGame.SpriteX(sprite);
			}
		}
		/// <summary>
		/// Draws projectile on to the screen.
		/// </summary>
		public void draw ()
		{
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
		/// <summary>
		/// Gets the projectile
		/// </summary>
		/// <value>The sprite</value>
		public Sprite Sprite {
			get { 
				return sprite; 
			}
		}
	}
}
