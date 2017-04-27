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
		public UnitCell (Bitmap  bitmap,int bitmapX, int bitmapY,int x, int y, int width)
		{
			this.bitmap = bitmap;
			this.bitmapX = bitmapX;
			this.bitmapY = bitmapY;
			this.x = x;
			this.y = y;
			this.width = width;
			height = width;//Square
		}

		public void drawCell () {
			SwinGame.DrawBitmap (bitmap, bitmapX, bitmapY);
			SwinGame.DrawRectangle (Color.Black, x, y, width, height);
		}
		public bool isInCell (Point2D pt) {
			Console.WriteLine (SwinGame.PointInRect (pt, x, y, width, height));
			return SwinGame.PointInRect (pt,x,y,width,height);
		}
	}
}
