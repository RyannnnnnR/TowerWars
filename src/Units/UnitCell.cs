using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A class used to define unit cells
	/// </summary>
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
		/// <summary>
		/// Draws cell on to the screen.
		/// </summary>
		public void drawCell () {
			SwinGame.DrawRectangle (Color.Black, x, y, width, height);
			SwinGame.DrawText (type.ToString (), Color.White, labelX, labelY);

		}
		/// <summary>
		/// Checks whether mouse position is in a cell.
		/// </summary>
		/// <returns>Returns whether mouse was in cell.</returns>
		/// <param name="pt">Mouse Position</param>
		public bool isInCell (Point2D pt) {
			return SwinGame.PointInRect (pt,x,y,width,height);
		}
		/// <summary>
		/// Returns the unit type associated with the cell.
		/// </summary>
		/// <value>The unit type.</value>
		public UnitType Type { 
			get { return type; }
		}
	}
}
