using System;
using SwinGameSDK;

namespace MyGame
{
	public class Currency
	{
		int amount = 0;
		private Bitmap coin;
		public Currency ()
		{
			coin = SwinGame.LoadBitmap ("coin.png");
		}

		public void draw () {
			SwinGame.DrawBitmap (coin, Position.COIN_X, Position.COIN_Y);
			SwinGame.DrawText (amount.ToString (), Color.White, Position.COIN_X + 25, Position.COIN_Y+5);
		}
	}
}
