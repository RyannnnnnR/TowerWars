using System;
using SwinGameSDK;

namespace MyGame
{
	public class Tower
	{
		private int health = 100;
		private int x;
		private int y;
		public Tower (int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public void updateHealth (int health) {
			this.health = health;
		}
		public void drawHealthBar () {
			SwinGame.FillRectangle (Color.LimeGreen, x, y, 40, 3);
		}
		public void drawHealthBar (float health) {
			SwinGame.FillRectangle (Color.LimeGreen, x, y, health, 3);
		}
		public void drawDamageTaken (float start,float dmgDone) {
			SwinGame.FillRectangle (Color.Red, x+start, y, dmgDone, 3);
			Console.WriteLine (x + start);

		}
		public void handleDamage (int dmg) {
			health -= dmg;//90
			Console.WriteLine ();
			float healthPercentage = (float)health / 100;
			float dmgedHealth = (float)40 * healthPercentage;
			drawHealthBar (dmgedHealth);//36 pixels long
			drawDamageTaken (dmgedHealth, 40-dmgedHealth);

		}
	}
}
