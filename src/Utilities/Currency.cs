using System;
using System.Threading;
using SwinGameSDK;

namespace MyGame
{
	public class Currency
	{
		int amount = 0;
		int delay = 60;
		private GameManager manager;
		private GamePainter painter;

		public Currency (GamePainter painter, GameManager manager)
		{
			this.manager = manager;
			this.painter = painter;
		}

		public void drawCoin ()
		{
			
			drawAmount ();
		}
		public void drawAmount ()
		{
			SwinGame.DrawText (amount.ToString (), Color.White, Position.COIN_X + 25, Position.COIN_Y + 5);
		}

		public void update ()
		{
			delay--;
			if (delay == 0)
				{
					amount++;
					delay = 60;
				}
				drawAmount ();
				painter.makeUnitsAvailable (amount);

		}
	}
}
