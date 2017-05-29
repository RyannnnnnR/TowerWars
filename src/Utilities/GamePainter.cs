using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// This class is in charge of painting all images/componets to the screen(i.e Unit cells, background, coin, etc)
	/// </summary>
	public class GamePainter
	{
		private Bitmap enemyBase;
		private Bitmap homeBase;
		private Bitmap background;
		private Bitmap utown;
		private Bitmap umage;
		private Bitmap uranger;
		private Bitmap uninja;
		private Bitmap uhealer;
		private Bitmap uwarrior;
		private Bitmap coin;
		private Bitmap town;
		private Bitmap mage;
		private Bitmap ranger;
		private Bitmap ninja;
		private Bitmap healer;
		private Bitmap warrior;
		private GameManager manager;
		private UnitCell townCell;
		private UnitCell mageCell;
		private UnitCell rangerCell;
		private UnitCell ninjaCell;
		private UnitCell healerCell;
		private UnitCell warriorCell;
		private Currency currency;
		public GamePainter (GameManager manager, Currency currency)
		{
			//Load bitmaps
			coin = SwinGame.LoadBitmap ("coin.png");
			enemyBase = SwinGame.LoadBitmap ("enemybase.png");
			homeBase = SwinGame.LoadBitmap ("homebase.png");
			background = SwinGame.LoadBitmap ("hills.png");
			town = SwinGame.LoadBitmap ("town.png");
			mage = SwinGame.LoadBitmap ("mage.png");
			ranger = SwinGame.LoadBitmap ("ranger.png");
			ninja = SwinGame.LoadBitmap ("ninja.png");
			healer = SwinGame.LoadBitmap ("healer.png");
			warrior = SwinGame.LoadBitmap ("warrior.png");
			utown = SwinGame.LoadBitmap ("townunavailable.png");
			umage = SwinGame.LoadBitmap ("mageunavailable.png");
			uranger = SwinGame.LoadBitmap ("rangerunavailable.png");
			uninja = SwinGame.LoadBitmap ("ninjaunavailable.png");
			uhealer = SwinGame.LoadBitmap ("healerunavailable.png");
			uwarrior = SwinGame.LoadBitmap ("warriorunavailable.png");
			this.manager = manager;
			this.currency = currency;
			InitialiseCells ();
		}
		/// <summary>
		/// Defines all unit cells.
		/// </summary>
		private void InitialiseCells () { 
			townCell = new UnitCell (Position.TOWN_CELL_X,Position.TOWN_LABEL_X, UnitType.Town);
			mageCell = new UnitCell (Position.MAGE_CELL_X, Position.MAGE_LABEL_X, UnitType.Mage);
			rangerCell = new UnitCell(Position.RANGER_CELL_X, Position.RANGER_LABEL_X, UnitType.Ranger);
			ninjaCell = new UnitCell (Position.NINJA_CELL_X,Position.NINJA_LABEL_X, UnitType.Ninja);
			healerCell = new UnitCell (Position.HEALER_CELL_X,Position.HEALER_LABEL_X, UnitType.Healer);
			warriorCell = new UnitCell (Position.WARRIOR_CELL_X, Position.WARRIOR_LABEL_X, UnitType.Warrior);
			manager.AddUnitCell (townCell);
			manager.AddUnitCell (mageCell);
			manager.AddUnitCell (rangerCell);
			manager.AddUnitCell (ninjaCell);
			manager.AddUnitCell (healerCell);
			manager.AddUnitCell (warriorCell);

		}
		/// <summary>
		/// Paints the background.
		/// </summary>
		public void paintBackground () {
			SwinGame.DrawBitmap (background, 0, 0);
		}
		/// <summary>
		/// Paints the enemey base.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void paintEnemeyBase (int x, int y)
		{
			SwinGame.DrawBitmap (enemyBase, x, y);
		}
		/// <summary>
		/// Paints the home base.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void paintHomeBase (int x, int y)
		{
			SwinGame.DrawBitmap (homeBase, x, y);
		}
		/// <summary>
		/// Draws the unit cells and checks whether player has enough money to buy units
		/// </summary>
		public void drawUnitCells ()
		{
			townCell.drawCell ();
			mageCell.drawCell ();
			rangerCell.drawCell ();
			ninjaCell.drawCell ();
			healerCell.drawCell ();
			warriorCell.drawCell ();
			Bitmap availTown = currency.Amount >= currency.PriceList[UnitType.Town] ? town : utown;
			Bitmap availRanger = currency.Amount >= currency.PriceList[UnitType.Ranger] ? ranger : uranger;
			Bitmap availMage = currency.Amount >= currency.PriceList[UnitType.Mage] ? mage : umage;
			Bitmap availNinja = currency.Amount >= currency.PriceList[UnitType.Ninja] ? ninja : uninja;
			Bitmap availHealer = currency.Amount >= currency.PriceList[UnitType.Healer] ? healer : uhealer;
			Bitmap availWarrior = currency.Amount >= currency.PriceList[UnitType.Warrior] ? warrior : uwarrior;
			SwinGame.DrawBitmap (availTown, Position.TOWN_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availRanger, Position.RANGER_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availMage, Position.MAGE_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availNinja, Position.NINJA_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availHealer, Position.HEALER_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availWarrior, Position.WARRIOR_IMAGE_X, Position.IMAGE_Y);
			//Add cells to list in game (interactions) manager.

		}
		/// <summary>
		/// Paints all components.
		/// </summary>
		public void Paint () {
			paintBackground ();
			SwinGame.DrawBitmap (coin, Position.COIN_X, Position.COIN_Y);
			drawUnitCells ();
		}

	}
}
