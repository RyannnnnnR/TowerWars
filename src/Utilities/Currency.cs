using System;
using System.Collections.Generic;
using System.Threading;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A currency class allowing players to buy units.
	/// </summary>
	public class Currency
	{
		private int amount = 0;
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
		/// <summary>
		/// Draws the amount of money the player has.
		/// </summary>
		public void drawAmount ()
		{
			SwinGame.DrawText (amount.ToString (), Color.White, Position.COIN_X + 25, Position.COIN_Y + 5);
		}
		/// <summary>
		/// Updates currency by 2 every second.
		/// </summary>
		public void update ()
		{
			delay--;
			if (delay == 0)
				{
					amount+=2;
					delay = 60;
				}
				drawAmount ();

		}
		/// <summary>
		/// A Property that dynamically keep track of all unit prices
		/// </summary>
		/// <value>The price list.</value>
		public Dictionary<UnitType, int> PriceList { 
			get { return pricelist; }
		}
		/// <summary>
		/// A property that keeps track of how much money the player has.
		/// </summary>
		/// <value>The amount.</value>
		public int Amount {
			get {
				return amount;
			}
			set { amount = value; }
		}

	}
}
