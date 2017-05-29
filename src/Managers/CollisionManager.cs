using System;
using System.Diagnostics;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// A class used to handle collision detection.
	/// </summary>
	/// <remarks>
	/// SwinGame as collision detection, but it was inconsistent amoung different operating systems
	/// see: https://github.com/macite/swingame/issues/48
	/// </remarks>
	public class CollisionManager
	{
		TeamManager manager;
		GameManager gameManager;
		HealthManager healthManager;
		Random random = new Random ();
		HomeTower home;
		EnemyTower enemy;
		public CollisionManager (GameManager gameManager,TeamManager manager, HealthManager healthManager, HomeTower home, EnemyTower enemy)
		{
			this.gameManager = gameManager;
			this.home = home;
			this.enemy = enemy;
			this.manager = manager;
			this.healthManager = healthManager;
		}
		/// <summary>
		/// Checks periodically for collisions
		/// </summary>
		public void handleCollisions () {
			handleCollisionBetweenEntities ();
			handleCollisionsBetweenTowerAndEntity ();
		}
		/// <summary>
		/// Handles when characters collide and when projectiles collide with characters
		/// </summary>
		private void handleCollisionBetweenEntities ()
		{
			if (manager.Heroes.Count > 0 && manager.Enemies.Count > 0) {
				foreach (Unit heros in manager.Heroes) {
					Healer healer = null;
					if (heros.getName () == "healer") {
						healer = heros as Healer;
						foreach (Unit others in manager.Heroes) {
							if (healer.inRange (others)) {
								if (healer != others) {
									if (SwinGame.SpriteDX (healer.Spirte) != 0) {
										SwinGame.SpriteSetDX (healer.Spirte, 0);
										healer.Cast (others);
									}
								}
							} else if (!healer.inRange (others)) {
								if (SwinGame.SpriteDX (healer.Spirte) == 0) {
									SwinGame.SpriteSetDX (healer.Spirte, 0.4f);
								}
							}
						}
					}
					foreach (Unit enemies in manager.Enemies) {
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
						if (heros.getName () == "mage") {
							Mage mage = heros as Mage;
							if (mage.inRange (enemies)) {
								if (SwinGame.SpriteDX (mage.Spirte) != 0) {
									SwinGame.SpriteSetDX (mage.Spirte, 0);
								}
								mage.Cast ();

								if (detectCollision (mage.fireball, enemies)) {
									enemies.SetLocation (SwinGame.SpriteX (enemies.Spirte) + 10.0f, Position.ENEMY_SPAWN_Y);
									mage.fireball = null;
									healthManager.handleUnitDamage (enemies, mage.SpellDmg);

								}
							} else if (!mage.inRange (enemies)) {
								if (SwinGame.SpriteDX (mage.Spirte) == 0) {
									SwinGame.SpriteSetDX (mage.Spirte, 0.4f);
								}
							}

						}
						if (heros.getName () == "ranger") {
							Ranger ranger = heros as Ranger;
							if (ranger.inRange (enemies)) {
								if (SwinGame.SpriteDX (ranger.Spirte) != 0) {
									SwinGame.SpriteSetDX (ranger.Spirte, 0);
								}
								ranger.attack ();

								if (detectCollision (ranger.Arrow, enemies)) {
									enemies.SetLocation (SwinGame.SpriteX (enemies.Spirte) + 10.0f, Position.ENEMY_SPAWN_Y);
									ranger.Arrow = null;
									healthManager.handleUnitDamage (enemies, ranger.ArrowDmg);

								}
							} else if (!ranger.inRange (enemies)) {
								if (SwinGame.SpriteDX (ranger.Spirte) == 0) {
									SwinGame.SpriteSetDX (ranger.Spirte, 0.4f);
								}
							}

						}
					}
				}
			}
		}
		/// <summary>
		/// Checks to see if players are colliding with towers
		/// </summary>
		private void handleCollisionsBetweenTowerAndEntity () {
				if (manager.Enemies.Count > 0 && manager.Heroes.Count == 0) {
					foreach (Unit enemies in manager.Enemies) {
						if (detectCollision (enemies, home, MovementDirection.Left)) {
							SwinGame.SpriteSetDX (enemies.Spirte, 0);
							healthManager.handleTowerDamage (home, enemies.Dmg * 0.25f);
							if (home.Health <= 0) {
								gameManager.Running = false;
								gameManager.PlayerWon = false;
							}
						}
					}
				} 

				if(manager.Enemies.Count == 0 && manager.Heroes.Count > 0) {
					foreach (Unit heros in manager.Heroes) {
							if (detectCollision (heros, enemy, MovementDirection.Right)) {
								SwinGame.SpriteSetDX (heros.Spirte, 0);
								healthManager.handleTowerDamage (enemy, heros.Dmg * 0.10f);
								if (enemy.Health <= 0) {
								gameManager.Running = false;
							gameManager.PlayerWon = true;
							}
						}
					if (heros.getName () == "mage") {
							Mage mage = heros as Mage;
							if (mage.inRange (enemy)) {
								mage.Cast ();
								if (SwinGame.SpriteDX (mage.Spirte) != 0) {
									SwinGame.SpriteSetDX (mage.Spirte, 0);
								}
								if (detectCollision (mage.fireball, enemy)) {
									mage.fireball = null;
									healthManager.handleTowerDamage (enemy, mage.SpellDmg);
									
								}
							} else if (!mage.inRange (enemy)) {
								if (SwinGame.SpriteDX (mage.Spirte) == 0) {
									SwinGame.SpriteSetDX (mage.Spirte, 0.4f);
								}
							}
						}
					if (heros.getName () == "ranger") {
							Ranger ranger = heros as Ranger;
							if (ranger.inRange (enemy)) {
								ranger.attack ();
								if (SwinGame.SpriteDX (ranger.Spirte) != 0) {
									SwinGame.SpriteSetDX (ranger.Spirte, 0);
								}
								if (detectCollision (ranger.Arrow, enemy)) {
									ranger.Arrow = null;
									healthManager.handleTowerDamage (enemy, ranger.ArrowDmg);
									
								}
							} else if (!ranger.inRange (enemy)) {
								if (SwinGame.SpriteDX (ranger.Spirte) == 0) {
									SwinGame.SpriteSetDX (ranger.Spirte, 0.4f);
								}
							}
						}
					}
				}
		}
		/// <summary>
		/// Detects the collision between characters
		/// </summary>
		/// <returns><c>true</c>, if collision was detected, <c>false</c> otherwise.</returns>
		/// <param name="hero">Hero unit</param>
		/// <param name="enemy">Enemy.</param>
		public bool detectCollision (Unit hero, Unit enemy) {
				return hero.getX () + 12 >= enemy.getX ();
		}
		/// <summary>
		/// Detects collision between unit and tower
		/// </summary>
		/// <returns><c>true</c>, if collision was detected, <c>false</c> otherwise.</returns>
		/// <param name="unit">Unit unit</param>
		/// <param name="tower">Tower</param>
		/// <param name="direction">Movement Direction</param>
		/// <remarks>
		/// Movement direction used to differentiate unit(enemies and heroes)
		/// </remarks>
		public bool detectCollision (Unit unit, Tower tower, MovementDirection direction)
		{
			if (direction == MovementDirection.Left) {
				return unit.getX () <= tower.X + 50;
			} else {
				return unit.getX () + 45 >= tower.X;
			}
		}
		/// <summary>
		/// Detects the collision between projectile and enemy
		/// </summary>
		/// <returns><c>true</c>, if collision was detected, <c>false</c> otherwise.</returns>
		/// <param name="projectile">Projectile</param>
		/// <param name="enemy">Enemy</param>
		public bool detectCollision (Projectile projectile,  Unit enemy)
		{
			if (projectile == null)
				return false;
			return projectile.X+20 >= enemy.getX ();
		}
		/// <summary>
		/// Detects collisions between projectiles
		/// </summary>
		/// <returns><c>true</c>, if collision was detected, <c>false</c> otherwise.</returns>
		/// <param name="friendly">Friendly.</param>
		/// <param name="hostile">Hostile.</param>
		/// <remarks>
		/// Currently not used.
		/// </remarks>
		public bool detectCollision (Projectile friendly, Projectile hostile)
		{
			return friendly.X >= hostile.X;
		}
		/// <summary>
		/// Detects the collision between projectiles and tower
		/// </summary>
		/// <returns><c>true</c>, if collision was detected, <c>false</c> otherwise.</returns>
		/// <param name="projectile">Projectile.</param>
		/// <param name="tower">Tower.</param>
		public bool detectCollision (Projectile projectile, Tower tower)
		{
			if (projectile == null)
				return false;
			return projectile.X+50 >= tower.X;
		}

		
		}
	}
