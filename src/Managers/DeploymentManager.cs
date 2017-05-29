using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A class used to deploy hero and enemy characters
	/// </summary>
	public class DeploymentManager
	{
		private GameManager manager;
		private Currency currency;
		private TeamManager teamManager;
		private ErrorManager errManager;
		private int delay = 600;//Spawn enemy every 10 seconds
		public DeploymentManager (GameManager manager, Currency currency, TeamManager teamManager, ErrorManager errManager)
		{
			this.errManager = errManager;
			this.manager = manager;
			this.currency = currency;
			this.teamManager = teamManager;
		}
		/// <summary>
		/// Checks to see if player clicks are within the deployment cells.
		/// </summary>
		/// <returns>The unit type</returns>
		/// <param name="mouse">Mouse position</param>
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
		/// <summary>
		/// Deploys the unit based on the cell that was clicked.
		/// </summary>
		/// <returns>A new instance of a certain type of hero class</returns>
		/// <param name="type">Unit Type</param>
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
		/// <summary>
		/// Draws the units to the screen and deploys random enemies every 10 seconds.
		/// </summary>
		public void spawnUnits () {
			DeployRandomEnemy ();
			if (teamManager.Heroes.Count > 0) {
				foreach (Unit unit in teamManager.Heroes) {
						unit.draw ();
		
					}
				}
			if (teamManager.Enemies.Count > 0) {
				foreach (Unit unit in teamManager.Enemies) {
							unit.draw ();
						}
					}
		}
		/// <summary>
		/// Randomly chooses which eneny is going to be spawned.
		/// </summary>
		private void DeployRandomEnemy () {
			Random rand = new Random ();
			delay--;
			if (delay == 0) {
				int spawnrate = rand.Next (100);
				if (spawnrate > 0 && spawnrate <= 35) {
					Lizard ghost = new Lizard ();
					teamManager.AddEnemy(ghost);
				} else if (spawnrate > 35 && spawnrate <= 70) {
					Minotaur demon = new Minotaur ();
					teamManager.AddEnemy(demon);
				} else if (spawnrate > 70 && spawnrate <= 80) {
					Phoenix phoenix = new Phoenix ();
					teamManager.AddEnemy (phoenix);

				} else if (spawnrate > 80 && spawnrate <= 90) {
					Cactus cactus = new Cactus ();
					teamManager.AddEnemy(cactus);
				} else if (spawnrate > 90 && spawnrate <= 100) {
					Tree tree = new Tree ();
					teamManager.AddEnemy (tree);
				}
				delay = 600;
			}

			}
		}

	}