using System;
using SwinGameSDK;

namespace MyGame
{
	public class UnitCell
	{
		private int x;
		private int y;
		private int width;
		private int height;
		private int labelX;
		private int labelY;
		private UnitType type;
		public UnitCell (int x,int labelX, UnitType type)
		{
			this.x = x;
			this.y = Position.CELL_Y;
			this.width = Position.CELL_WIDTH_HEIGHT;
			this.height = width;//Square
			this.labelX = labelX;
			this.labelY = Position.LABEL_Y;
			this.type = type;
		}
		public void drawCell () {
			SwinGame.DrawRectangle (Color.Black, x, y, width, height);
			SwinGame.DrawText (type.ToString (), Color.White, labelX, labelY);

		}
		public bool isInCell (Point2D pt) {
			return SwinGame.PointInRect (pt,x,y,width,height);
		}

		public UnitType Type { 
			get { return type; }
		}
	}
}
