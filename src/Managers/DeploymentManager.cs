using System;
using SwinGameSDK;

namespace MyGame
{
	public class DeploymentManager
	{
		private Unit unit;
		private GameManager manager;
		private Currency currency;
		private TeamManager teamManager;
		public DeploymentManager (GameManager manager, Currency currency, TeamManager teamManager)
		{
			this.manager = manager;
			this.currency = currency;
			this.teamManager = teamManager;
		}

		public Unit handleInput (Point2D mouse) {
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
			foreach (UnitCell cell in manager.UnitCells) {
					if (cell.isInCell (mouse)) {
						if (currency.Amount >= currency.PriceList [cell.Type]) {
							return Deloy (cell.Type);
						} else {
							Console.WriteLine ("Not enough money!");
						}
					}
				}
			}
			return null;
		}
		public Unit Deloy (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				currency.Amount -= currency.PriceList [UnitType.Town];
				Town town = new Town ();
				teamManager.AddHero (town);
				return town;
			case UnitType.Mage:
				Mage mage = new Mage ();
				teamManager.AddHero (mage);
				return mage;
			case UnitType.Ranger:
				Ranger ranger = new Ranger ();
				teamManager.AddHero (ranger);
				return ranger;
			case UnitType.Ninja:
				Ninja ninja = new Ninja ();
				teamManager.AddHero (ninja);
				return ninja;
			case UnitType.Healer:
				Healer healer = new Healer ();
				teamManager.AddHero (healer);
				return healer;
			case UnitType.Warrior:
				Warrior warrior = new Warrior ();
				teamManager.AddHero (warrior);
				return warrior;
			default:
				return null;
			}
		}
	}
}
