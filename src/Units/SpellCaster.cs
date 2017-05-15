using System;
namespace MyGame
{
	public interface SpellCaster
	{
		int Mana { get; set; }
		void Cast ();
	}
}
