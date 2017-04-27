using System;
using SwinGameSDK;

namespace MyGame
{
	public class GamePainter
	{
		private Bitmap enemyBase;
		private Bitmap homeBase;
		private Bitmap background;
		private Bitmap town;
		private Bitmap mage;
		private Bitmap ranger;
		private GameManager manager;
		public GamePainter (GameManager manager)
		{
			//Load bitmaps
			enemyBase = SwinGame.LoadBitmap ("enemybase.png");
			homeBase = SwinGame.LoadBitmap ("homebase.png");
			background = SwinGame.LoadBitmap ("hills.png");
			town = SwinGame.LoadBitmap ("town.png");
			mage = SwinGame.LoadBitmap ("mage.png");
			ranger = SwinGame.LoadBitmap ("ranger.png");
			this.manager = manager;
		}

		public void paintBackground () {
			SwinGame.DrawBitmap (background, 0, 0);
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
			UnitCell townCell = new UnitCell (town, Position.TOWN_IMAGE_X, Position.IMAGE_Y, Position.TOWN_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT);
			UnitCell mageCell = new UnitCell (mage, Position.MAGE_IMAGE_X, Position.IMAGE_Y, Position.MAGE_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT);
			UnitCell rangerCell = new UnitCell (ranger, Position.RANGER_IMAGE_X, Position.IMAGE_Y, Position.RANGER_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT);
			townCell.drawCell ();
			mageCell.drawCell ();
			rangerCell.drawCell ();
			//Add cells to list in game (interactions) manager.

		}
		public void paintStartSequence () {
			paintBackground ();
			paintHomeBase (17, 490);
			paintEnemeyBase (740, 488);//Make bases bigger??
			drawUnitCells ();
		}

	}
}
