using System;
using SwinGameSDK;

namespace MyGame
{
	public class DeploymentManager
	{
		private GameManager manager;
		private Currency currency;
		private TeamManager teamManager;
		private int delay = 300;//Spawn enemy every 5 seconds???
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
							return DeloyHero (cell.Type);
						} else {
							SwinGame.DrawText ("Not enough money", Color.Red, 100, 100); 
						}
					}
				}
			}
			return null;
		}
		public void DeployEnemy () {
			delay--;
			if (delay == 0) { 
				
			}
		
		}
		public Unit DeloyHero (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				currency.Amount -= currency.PriceList [UnitType.Town];
				Town town = new Town ();
				teamManager.AddHero (town);
				return town;
			case UnitType.Mage:
				currency.Amount -= currency.PriceList [UnitType.Mage];
				Mage mage = new Mage ();
				teamManager.AddHero (mage);
				return mage;
			case UnitType.Ranger:
				currency.Amount -= currency.PriceList [UnitType.Ranger];
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
		private Unit getRandomEnemy () {
			Random rand = new Random ();
			return null;
		}

	}
}
