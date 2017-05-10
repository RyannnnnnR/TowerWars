using System;
namespace MyGame
{
	public class Demon : Unit
	{
		public Demon () : base("monster4.png", "monsterwalking.txt")
		{
		}

		public override string getName ()
		{
			return "demon";
		}
	}
}
