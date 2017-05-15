using System;
using SwinGameSDK;

namespace MyGame
{
	public class CollisionManager
	{
		TeamManager manager;
		HealthManager healthManager;
		Random random = new Random ();
		public CollisionManager (TeamManager manager, HealthManager healthManager)
		{
			this.manager = manager;
			this.healthManager = healthManager;
		}

		public void handleCollisions () {
			if (manager.enemies.Count > 0 && manager.heros.Count > 0) {
				foreach (Unit heros in manager.heros) {
					foreach (Unit enemies in manager.enemies) {
						if(SwinGame.SpriteCollision(heros.Spirte, enemies.Spirte)) {
							int hit = random.Next (2);//Battle interaction - who hit who
							if (hit == 0) {
								int dmg = heros.Dmg;
								healthManager.handleUnitDamage (enemies, dmg);
								enemies.SetLocation (SwinGame.SpriteX(enemies.Spirte) + 40.0f, Position.SPAWN_Y);//Knockback
							} else {
								int dmg = enemies.Dmg;
								healthManager.handleUnitDamage (heros, dmg);
								heros.SetLocation (SwinGame.SpriteX(heros.Spirte) - 40.0f, Position.SPAWN_Y);
							}
						}
					}
				}
			}
		
		}
	}
}
