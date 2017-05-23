using System;
using System.Diagnostics;
using SwinGameSDK;

namespace MyGame
{
	public class CollisionManager
	{
		TeamManager manager;
		GameManager gameManager;
		HealthManager healthManager;
		Random random = new Random ();
		HomeTower home;
		EnemyTower enemy;
		private int delay = 30;
		public CollisionManager (GameManager gameManager,TeamManager manager, HealthManager healthManager, HomeTower home, EnemyTower enemy)
		{
			this.gameManager = gameManager;
			this.home = home;
			this.enemy = enemy;
			this.manager = manager;
			this.healthManager = healthManager;
		}
		public void handleCollisions () {
			handleCollisionBetweenEntities ();
			handleCollisionsBetweenTowerAndEntity ();
		}
		private void handleCollisionBetweenEntities () {
				if (manager.heros.Count > 0 && manager.enemies.Count > 0) {
					foreach (Unit heros in manager.heros) {
						foreach (Unit enemies in manager.enemies) {
						if (detectCollision (heros, enemies)) {//Spoof collision detection
							int hit = random.Next (2);//Battle interaction - who hit who
							if (hit == 0) {
								float dmg = heros.Dmg;
								healthManager.handleUnitDamage (enemies, dmg);
								enemies.SetLocation (SwinGame.SpriteX (enemies.Spirte) + 30.0f, Position.ENEMY_SPAWN_Y);//Knockback
							} else {
								float dmg = enemies.Dmg;
								healthManager.handleUnitDamage (heros, dmg);
								heros.SetLocation (SwinGame.SpriteX (heros.Spirte) - 30.0f, Position.HERO_SPAWN_Y);
							}
						}
						}
					}
				}
				}
		private void handleCollisionsBetweenTowerAndEntity () {
			delay--;
			if (delay == 0) {//Check every second to balance dmg
				if (manager.enemies.Count > 0 && manager.heros.Count == 0) {
					foreach (Unit enemies in manager.enemies) {
						if (detectCollision (enemies, home, MovementDirection.Left)) {
							SwinGame.SpriteSetDX (enemies.Spirte, 0);
							healthManager.handleTowerDamage (home, enemies.Dmg * 0.25f);
							if (home.Health <= 0) {
								gameManager.State = GameState.Ended;
							}
						}
					}
				} else if (manager.enemies.Count == 0 && manager.heros.Count > 0) {
					foreach (Unit heros in manager.heros) {
						if (detectCollision (heros, enemy, MovementDirection.Right)) {
							SwinGame.SpriteSetDX (heros.Spirte, 0);
							healthManager.handleTowerDamage (enemy, heros.Dmg * 0.25f);
							if (enemy.Health <= 0) {
								gameManager.State = GameState.Ended;
							}
						}
					}
				}
				delay = 30;
			}
		}

		public bool detectCollision (Unit hero, Unit enemy) {
			return hero.getX () + 12 >= enemy.getX ();
		}
		public bool detectCollision (Unit unit, Tower tower, MovementDirection direction)
		{
			if (direction == MovementDirection.Left) {
				return unit.getX () <= tower.X + 50;
			} else {
				return unit.getX () + 45 >= tower.X;
			}
		}
		public bool detectCollision (Projectile projectile,  Unit enemy)
		{
			return projectile.X >= enemy.getX ();
		}
		public bool detectCollision (Projectile friendly, Projectile hostile)
		{
			return friendly.X >= hostile.X;
		}
		public bool detectCollision (Projectile projectile, Tower tower)
		{
			return true;
		}

		
		}
	}
