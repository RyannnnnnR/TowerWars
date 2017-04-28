using System;
using SwinGameSDK;

namespace MyGame
{
	public class Warrior : Unit, PhysicalAttcker
	{
		Sprite sprite;
		public Warrior ()
		{
			SwinGame.LoadResourceBundle ("warriorbundle.txt");
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed("warriorspritesheet"), SwinGame.AnimationScriptNamed("warriorwalking"));
		}

		public int dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public int attack ()
		{
			throw new NotImplementedException ();
		}

		public override void move ()
		{
			SwinGame.SpriteStartAnimation (sprite, "warriorwalking");
			SwinGame.SpriteSetX (sprite, Position.SPAWN_X);
			SwinGame.SpriteSetY (sprite, Position.SPAWN_Y);
			while (true) {
				{
					SwinGame.DrawSprite (sprite);
					SwinGame.RefreshScreen (60);
					SwinGame.UpdateSprite (sprite);
					SwinGame.ProcessEvents ();
				}
			}
		}
	}
}
