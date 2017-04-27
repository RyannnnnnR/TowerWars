using System;
using SwinGameSDK;

namespace MyGame
{
	public class UnitCell
	{
		private Bitmap bitmap;
		private int bitmapX;
		private int bitmapY;
		private int x;
		private int y;
		private int width;
		private int height;
		private int labelX;
		private int labelY;
		private UnitType type;
		public UnitCell (Bitmap  bitmap,int bitmapX, int bitmapY,int x, int y, int width, int labelX, int labelY, UnitType type)
		{
			this.bitmap = bitmap;
			this.bitmapX = bitmapX;
			this.bitmapY = bitmapY;
			this.x = x;
			this.y = y;
			this.width = width;
			height = width;//Square
			this.labelX = labelX;
			this.labelY = labelY;
			this.type = type;
		}
		public void drawCell () {
			SwinGame.DrawBitmap (bitmap, bitmapX, bitmapY);
			SwinGame.DrawRectangle (Color.Black, x, y, width, height);
			SwinGame.DrawText (type.ToString (), Color.Black, labelX, labelY);

		}
		public bool isInCell (Point2D pt) {
			return SwinGame.PointInRect (pt,x,y,width,height);
		}

		public UnitType Type { 
			get { return type; }
		}
	}
}
