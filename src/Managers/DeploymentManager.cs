using System;
using SwinGameSDK;

namespace MyGame
{
	public class DeploymentManager
	{
		private GameManager manager;
		private Currency currency;
		private TeamManager teamManager;
		private ErrorManager errManager;
		private int delay = 300;//Spawn enemy every 5 seconds???
		public DeploymentManager (GameManager manager, Currency currency, TeamManager teamManager, ErrorManager errManager)
		{
			this.errManager = errManager;
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
							errManager.Error = Messages.ERROR_NOT_ENOUGH_MONEY;
		 
						}
					}
				}
			}
			return null;
		}
		public Unit DeloyHero (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				currency.Amount -= currency.PriceList [UnitType.Town];
				Town town = new Town (10);
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
		public void spawnUnits () {
			//DeployRandomEnemy ();
			if (teamManager.heros.Count > 0) {
					foreach (Unit unit in teamManager.heros) {
						unit.move ();
					}
				}
			if (teamManager.enemies.Count > 0) {
				foreach (Unit unit in teamManager.enemies) {
							unit.move ();
						}
					}
		}
		private void DeployRandomEnemy () {
			Random rand = new Random ();
			delay--;
			if (delay == 0) {
				int spawnrate = rand.Next (100);
				if (spawnrate > 0 && spawnrate <= 35) {
					Ghost ghost = new Ghost ();
					teamManager.enemies.Add (ghost);
				} else if (spawnrate > 35 && spawnrate <= 70) {
					Demon demon = new Demon ();
					teamManager.enemies.Add (demon);
				} else if (spawnrate > 70 && spawnrate <= 80) {
					Phoenix phoenix = new Phoenix ();
					teamManager.enemies.Add (phoenix);

				} else if (spawnrate > 80 && spawnrate <= 90) {
					Cactus cactus = new Cactus (3);
					teamManager.enemies.Add (cactus);
				} else if (spawnrate > 90 && spawnrate <= 100) {
					Tree tree = new Tree ();
					teamManager.enemies.Add (tree);
				}
				delay = 300;
			}

			}
		}

	}