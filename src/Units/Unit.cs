using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Unit
	{
		private int health;
		private int movementSpeed;
		private string bitmap;
		private string animation;
		private Sprite sprite;
		public Unit (string bitmap, string animation)
		{
			SwinGame.LoadResourceBundle ("characterbundle.txt");
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed (animation));
		}
		public void SetLocation (int x, int y) {
			SwinGame.SpriteSetX (sprite, x);
			SwinGame.SpriteSetY (sprite, y);
		}
		public void move () { 
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");
			while (true) {
				//Detect collision
				draw ();
				SwinGame.RefreshScreen (60);
				SwinGame.ProcessEvents ();
			}
		}
		public void draw () { 
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
	}
}
