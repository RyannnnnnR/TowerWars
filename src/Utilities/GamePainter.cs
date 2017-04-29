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
		private Bitmap ninja;
		private Bitmap healer;
		private GameManager manager;
		private UnitCell townCell;
		private UnitCell mageCell;
		private UnitCell rangerCell;
		private UnitCell ninjaCell;
		private UnitCell healerCell;
		private HomeTower t = new HomeTower ();
		private EnemyTower et = new EnemyTower ();
		public GamePainter (GameManager manager)
		{
			//Load bitmaps
			enemyBase = SwinGame.LoadBitmap ("enemybase.png");
			homeBase = SwinGame.LoadBitmap ("homebase.png");
			background = SwinGame.LoadBitmap ("hills.png");
			town = SwinGame.LoadBitmap ("townunavailable.png");
			mage = SwinGame.LoadBitmap ("mageunavailable.png");
			ranger = SwinGame.LoadBitmap ("rangerunavailable.png");
			ninja = SwinGame.LoadBitmap ("ninjaunavailable.png");
			healer = SwinGame.LoadBitmap ("healerunavailable.png");
			this.manager = manager;
			InitialiseCells ();
		}
		private void InitialiseCells () { 
			townCell = new UnitCell (town, Position.TOWN_IMAGE_X, Position.IMAGE_Y, Position.TOWN_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT, Position.TOWN_LABEL_X, Position.LABEL_Y, UnitType.Town);
			mageCell = new UnitCell (mage, Position.MAGE_IMAGE_X, Position.IMAGE_Y, Position.MAGE_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT, Position.MAGE_LABEL_X, Position.LABEL_Y, UnitType.Mage);
			rangerCell = new UnitCell (ranger, Position.RANGER_IMAGE_X, Position.IMAGE_Y, Position.RANGER_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT, Position.RANGER_LABEL_X, Position.LABEL_Y, UnitType.Ranger);
			ninjaCell = new UnitCell (ninja, Position.NINJA_IMAGE_X, Position.IMAGE_Y, Position.NINJA_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT, Position.HEALER_LABEL_X, Position.LABEL_Y, UnitType.Healer);
			healerCell = new UnitCell (healer, Position.HEALER_IMAGE_X, Position.IMAGE_Y, Position.HEALER_CELL_X, Position.CELL_Y, Position.CELL_WIDTH_HEIGHT, Position.NINJA_LABEL_X, Position.LABEL_Y, UnitType.Ninja);
			manager.AddUnitCell (townCell);
			manager.AddUnitCell (mageCell);
			manager.AddUnitCell (rangerCell);
			manager.AddUnitCell (ninjaCell);
			manager.AddUnitCell (healerCell);

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
			townCell.drawCell ();
			mageCell.drawCell ();
			rangerCell.drawCell ();
			//Add cells to list in game (interactions) manager.

		}
		public void paintStartSequence () {
			paintBackground ();
			paintHomeBase (Position.HOME_BASE_X, Position.HOME_BASE_Y);
			SwinGame.DrawBitmap (SwinGame.LoadBitmap ("town.png"),79, 520);
			new Currency ().draw ();
			paintEnemeyBase (Position.ENEMY_BASE_X, Position.ENEMY_BASE_Y);//Make bases bigger??
			drawUnitCells ();
		}

	}
}
