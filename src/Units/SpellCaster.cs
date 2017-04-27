using System;
namespace MyGame
{
	public interface SpellCaster
	{
		int Mana { get; set; }
		int spellDmg{get; set;}
		void Cast ();
	}
}
