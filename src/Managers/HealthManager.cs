using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A class used to track the health status of heroes, enemies and towers.
	/// </summary>
	public class HealthManager
	{
		private TeamManager manager;
		private List<Unit> deadHeros;
		private List<Unit> deadEnemies;
		private HomeTower home;
		private EnemyTower enemy;
		public HealthManager (TeamManager manager, HomeTower home, EnemyTower enemy)
		{
			this.home = home;
			this.enemy = enemy;
			this.manager = manager;
			deadHeros = new List<Unit> ();
			deadEnemies = new List<Unit> ();
		}
		/// <summary>
		/// Handles the unit damage.
		/// </summary>
		/// <param name="unit">The unit getting attacked</param>
		/// <param name="dmg">The amount of damage the unit is taking</param>
		public void handleUnitDamage (Unit unit, float dmg)
		{
			unit.Health -= dmg;
			if (unit.getName () == "ninja"){
				unit.Health -= dmg * 1.25f;
			}
			if (unit.getName () == "warrior") {
				unit.Health -= dmg * 0.25f;
			}
		}
		/// <summary>
		/// Handles the tower damage.
		/// </summary>
		/// <param name="tower">The tower being attacked</param>
		/// <param name="dmg">The amount of damage the tower is taking</param>
		public void handleTowerDamage (Tower tower, float dmg) {
			tower.Health -= dmg;
		}
		/// <summary>
		/// Contantly updates the health of all entities.
		/// </summary>
		/// <remarks>
		/// Handles death of units as well.
		/// </remarks>
		public void updateHealth ()
		{
			drawTowerHealthBar (home.Health,Position.HOME_HEALTH_BAR_X, Position.HEALTH_BAR_Y);
            drawTowerHealthBar (enemy.Health, Position.ENEMY_HEALTH_BAR_X, Position.HEALTH_BAR_Y);
			if (manager.Heroes.Count > 0) {
				foreach (Unit unit in manager.Heroes) {
					if (unit.Health <= 0) {
							deadHeros.Add (unit);
						}
						drawHealthBar (unit.Health, unit.getX (), unit.getY () + 40);
					}
				}
				if (manager.Enemies.Count > 0) {
					foreach (Unit unit in manager.Enemies) {
						if (unit.Health <= 0) {
							deadEnemies.Add(unit);

						}

						drawHealthBar (unit.Health, unit.getX () + 8, unit.getY () + 60);
					}
				}
			if (deadHeros.Count > 0) {
				foreach (Unit dead in deadHeros) {
					manager.Heroes.Remove (dead);
				}
			}
			if (deadEnemies.Count > 0) {
				foreach (Unit dead in deadEnemies){
					manager.Enemies.Remove (dead);
			}
		}
		}
		/// <summary>
		/// Draws the health bar above the tower
		/// </summary>
		/// <param name="health">Amount of health the tower has</param>
		/// <param name="x">The x coordinate of the bar</param>
		/// <param name="y">The y coordinate of the bar</param>
		public void drawTowerHealthBar (float health, float x, float y) { 
			health /= 300.0f;
			float length = 30.0f * health;
			float dmg = 30.0f - length;
			SwinGame.FillRectangle (Color.LimeGreen, x, y, length, 3);
			SwinGame.FillRectangle (Color.Red, x + length, y, dmg, 3);

		}
		/// <summary>
		/// Draw the health bar below units.
		/// </summary>
		/// <param name="health">The health of the units</param>
		/// <param name="x">The x coordinate of the bar</param>
		/// <param name="y">The y coordinate of the bar.</param>
		public void drawHealthBar (float health, float x, float y)
		{
			
			health /= 100.0f;
			float length = 30.0f * health;
			float dmg = 30.0f - length;
			SwinGame.FillRectangle (Color.LimeGreen, x, y, length, 3);
			SwinGame.FillRectangle (Color.Red, x + length, y, dmg, 3);

		}
	}
}
