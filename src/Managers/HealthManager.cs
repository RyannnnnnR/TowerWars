using System;
using SwinGameSDK;

namespace MyGame
{
	public class HealthManager
	{
		TeamManager manager;
		public HealthManager (TeamManager manager)
		{
			this.manager = manager;
		}

		public void handleUnitDamage (Unit unit, int dmg)
		{
			unit.Health -= dmg;
		}
		public void handleTowerDamage (Tower tower) { }
		public void updateHealth () {
			if (manager.heros.Count > 0) {
				foreach (Unit unit in manager.heros) {
					drawHealthBar (unit.Health, unit.getX (), unit.getY () + 40);
				}
			}
				if (manager.enemies.Count > 0) {
				foreach (Unit unit in manager.enemies) {
					drawHealthBar (unit.Health, unit.getX ()+8, unit.getY () + 60);
				}
			}
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
