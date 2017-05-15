using System;
using System.Collections.Generic;
using System.Threading;
using SwinGameSDK;

namespace MyGame
{
	public class Currency
	{
		private int amount = 10;
		private int delay = 60;
		private Dictionary<UnitType, int> pricelist = new Dictionary<UnitType, int> ();
		private GameManager manager;

		public Currency (GameManager manager)
		{
			this.manager = manager;
			pricelist.Add (UnitType.Town, 10);
			pricelist.Add (UnitType.Ranger, 25);
			pricelist.Add (UnitType.Mage, 35);
			pricelist.Add (UnitType.Healer, 45);
			pricelist.Add (UnitType.Warrior, 55);
			pricelist.Add (UnitType.Ninja, 75);
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
		public Dictionary<UnitType, int> PriceList { 
			get { return pricelist; }
		}
		public int Amount {
			get {
				return amount;
			}
			set { amount = value; }
		}

	}
}
