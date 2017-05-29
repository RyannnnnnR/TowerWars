using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Defines healer hero character
	/// </summary>
	/// <remarks>
	/// Support character, does no physical attack but heals damaged units
	/// </remarks>
	public class Healer : Unit
	{
		private Sprite effect = null;
		public Healer () : base ("healerBmp", "healerWalkingScrpt", 0.3f, 0, false)
		{
		}
		/// <summary>
		/// Checks to see if a hero is in the healers range
		/// </summary>
		/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
		/// <param name="hero">Hero.</param>
		public bool inRange (Unit hero)
		{
			float fieldOfView = this.getX () + 150;
				if (fieldOfView >= hero.getX ()) {
					return true;
			}
			return false;
		}
		/// <summary>
		/// Creates a visual healing effect
		/// </summary>
		/// <returns>The effect.</returns>
		/// <param name="hero">Hero.</param>
		public Sprite createEffect (Unit hero) { 
			Sprite sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed ("effectsBmp"), SwinGame.AnimationScriptNamed ("healingScrpt"));
			SwinGame.SpriteStartAnimation (sprite, "healing_effect");
			SwinGame.SpriteSetX (sprite, hero.getX()-70);
			SwinGame.SpriteSetY (sprite, hero.getY ()-80);
			return sprite;
		}
		/// <summary>
		/// Cast effect on selected hero
		/// </summary>
		/// <returns>The cast.</returns>
		/// <param name="hero">Hero.</param>
		public void Cast (Unit hero) {
			if (effect == null) {
				effect = createEffect (hero);
			}
			if (hero != this) {
				if (hero.Health <= 80) {
					SwinGame.DrawSprite (effect);
					SwinGame.UpdateSprite (effect);
					if (effect.AnimationHasEnded) {
						if (hero.Health + 20 > 100) {
							hero.Health = 100;
						} else {
							hero.Health += 20;
						}
						SwinGame.FreeSprite (effect);
						Console.WriteLine (hero.Health);
						effect = null;
					}
				}
			}
			}
		public override string getName ()
		{
			return "healer";
		}
	}
}
