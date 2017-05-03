using System;
using SwinGameSDK;

namespace MyGame
{
	public class DeploymentManager
	{
		private Unit unit;
		private GameManager manager;
		public DeploymentManager (GameManager manager)
		{
			this.manager = manager;
		}

		public Unit handleInput (Point2D mouse) {
				foreach (UnitCell cell in manager.UnitCells) {
					if (cell.isInCell (mouse)) {
					Console.WriteLine (cell.Type);
						return Deloy (cell.Type);
					}
				}
			return null;
		
		}
		public Unit Deloy (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				Town town = new Town ();
				return town;
			case UnitType.Mage:
				Mage mage = new Mage ();
				return mage;
			case UnitType.Ranger:
				Ranger ranger = new Ranger ();
				return ranger;
			case UnitType.Ninja:
				Ninja ninja = new Ninja ();
				return ninja;
			case UnitType.Healer:
				Healer healer = new Healer ();
				return healer;
			case UnitType.Warrior:
				Warrior warrior = new Warrior ();
				return warrior;
			default:
				return null;
			}
		}
	}
}
