using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
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

		public void handleUnitDamage (Unit unit, float dmg)
		{
			unit.Health -= dmg;
			if (unit.getName () == "ninja"){
				unit.Health -= dmg * 1.25f;
			}
		}
		public void handleTowerDamage (Tower tower, float dmg) {
			tower.Health -= dmg;
		}
		public void updateHealth ()
		{
			drawTowerHealthBar (home.Health, home.X+5, home.Y - 5);
			drawTowerHealthBar (enemy.Health, enemy.X+5, enemy.Y - 5);
			if (manager.heros.Count > 0) {
				foreach (Unit unit in manager.heros) {
					if (unit.Health <= 0) {
							deadHeros.Add (unit);
						}
						drawHealthBar (unit.Health, unit.getX (), unit.getY () + 40);
					}
				}
				if (manager.enemies.Count > 0) {
					foreach (Unit unit in manager.enemies) {
						if (unit.Health <= 0) {
							deadEnemies.Add(unit);

						}

						drawHealthBar (unit.Health, unit.getX () + 8, unit.getY () + 60);
					}
				}
			if (deadHeros.Count > 0) {
				foreach (Unit dead in deadHeros) {
					manager.heros.Remove (dead);
				}
			}
			if (deadEnemies.Count > 0) {
				foreach (Unit dead in deadEnemies){
					manager.enemies.Remove (dead);
			}
		}
		}
		public void drawTowerHealthBar (float health, float x, float y) { 
			health /= 300.0f;
			float length = 30.0f * health;
			float dmg = 30.0f - length;
			SwinGame.FillRectangle (Color.LimeGreen, x, y, length, 3);
			SwinGame.FillRectangle (Color.Red, x + length, y, dmg, 3);

		}
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
