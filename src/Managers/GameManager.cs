using System;
using System.Collections.Generic;

namespace MyGame
{
	public class GameManager
	{
		List<UnitCell> unitcells;
		private GameState state = GameState.Running;
		public GameManager ()
		{
			unitcells = new List<UnitCell> ();
		}

		public void AddUnitCell (UnitCell cell) {
			unitcells.Add (cell);
		}
		public GameState State { 
			get { return state;}
			set { state = value;}
		}
		public List<UnitCell> UnitCells {
			get {
				return unitcells;
			}
		}

	}
}
