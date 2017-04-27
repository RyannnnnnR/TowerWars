using System;
using System.Collections.Generic;

namespace MyGame
{
	public class GameManager
	{
		List<UnitCell> unitcells;
		public GameManager ()
		{
			unitcells = new List<UnitCell> ();
		}

		public void AddUnitCell (UnitCell cell) {
			unitcells.Add (cell);
		}
		public List<UnitCell> UnitCells {
			get {
				return unitcells;
			}
		}
	}
}
