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
								float dmg = heros.Dmg;
								healthManager.handleUnitDamage (enemies, dmg);
								//Console.WriteLine (heros.getName () + heros.Health);
								enemies.SetLocation (SwinGame.SpriteX(enemies.Spirte) + 30.0f, Position.SPAWN_Y);//Knockback
							} else {
								float dmg = enemies.Dmg;
								healthManager.handleUnitDamage (heros, dmg);
								//Console.WriteLine (enemies.getName () + enemies.Health);
								heros.SetLocation (SwinGame.SpriteX(heros.Spirte) - 30.0f, Position.SPAWN_Y);
							}
						}
					}
				}
			}
		
		}
	}
}
