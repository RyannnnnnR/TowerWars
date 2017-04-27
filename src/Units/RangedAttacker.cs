using System;
namespace MyGame
{
	public interface RangedAttacker
	{
		int dmg { get; set; }
		void attack ();
	}
}
