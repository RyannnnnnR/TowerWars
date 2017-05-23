using System;
using SwinGameSDK;

namespace MyGame
{
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
		private Bitmap coin;
		private Bitmap town;
		private Bitmap mage;
		private Bitmap ranger;
		private Bitmap ninja;
		private Bitmap healer;
		private GameManager manager;
		private UnitCell townCell;
		private UnitCell mageCell;
		private UnitCell rangerCell;
		private UnitCell ninjaCell;
		private UnitCell healerCell;
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
			utown = SwinGame.LoadBitmap ("townunavailable.png");
			umage = SwinGame.LoadBitmap ("mageunavailable.png");
			uranger = SwinGame.LoadBitmap ("rangerunavailable.png");
			uninja = SwinGame.LoadBitmap ("ninjaunavailable.png");
			uhealer = SwinGame.LoadBitmap ("healerunavailable.png");
			this.manager = manager;
			this.currency = currency;
			InitialiseCells ();
		}
		private void InitialiseCells () { 
			townCell = new UnitCell (Position.TOWN_CELL_X,Position.TOWN_LABEL_X, UnitType.Town);
			mageCell = new UnitCell (Position.MAGE_CELL_X, Position.MAGE_LABEL_X, UnitType.Mage);
			rangerCell = new UnitCell(Position.RANGER_CELL_X, Position.RANGER_LABEL_X, UnitType.Ranger);
			ninjaCell = new UnitCell (Position.NINJA_CELL_X,Position.HEALER_LABEL_X, UnitType.Healer);
			healerCell = new UnitCell (Position.HEALER_CELL_X,Position.NINJA_LABEL_X, UnitType.Ninja);
			manager.AddUnitCell (townCell);
			manager.AddUnitCell (mageCell);
			manager.AddUnitCell (rangerCell);
			manager.AddUnitCell (ninjaCell);
			manager.AddUnitCell (healerCell);

		}

		public void paintBackground () {
			SwinGame.DrawBitmap (background, 0, 0);
			//SwinGame.DrawBitmap (background, 800, 0);
		}
		public void paintEnemeyBase (int x, int y)
		{
			SwinGame.DrawBitmap (enemyBase, x, y);
		}
		public void paintHomeBase (int x, int y)
		{
			SwinGame.DrawBitmap (homeBase, x, y);
		}

		public void ClearScreen() {
			SwinGame.ClearScreen (Color.White);
			paintBackground();
		}
		public void drawUnitCells ()
		{
			//Start with 3 units 
			townCell.drawCell ();
			mageCell.drawCell ();
			rangerCell.drawCell ();
			Bitmap availTown = currency.Amount >= 10 ? town : utown;
			Bitmap availRanger = currency.Amount >= 25 ? ranger : uranger;
			Bitmap availMage = currency.Amount >= 35 ? mage : umage;

			SwinGame.DrawBitmap (availTown, Position.TOWN_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availRanger, Position.RANGER_IMAGE_X, Position.IMAGE_Y);
			SwinGame.DrawBitmap (availMage, Position.MAGE_IMAGE_X, Position.IMAGE_Y);
			//Add cells to list in game (interactions) manager.

		}
		public void Paint () {
			paintBackground ();
			SwinGame.DrawBitmap (coin, Position.COIN_X, Position.COIN_Y);
			drawUnitCells ();
		}

	}
}
