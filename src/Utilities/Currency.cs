using System;
using System.Threading;
using SwinGameSDK;

namespace MyGame
{
	public class Currency
	{
		private int amount = 0;
		private int delay = 60;
		private GameManager manager;

		public Currency (GameManager manager)
		{
			this.manager = manager;
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

		}
		public int Amount {
			get {
				return amount;
			}
			set { amount = value; }
		}

	}
}
