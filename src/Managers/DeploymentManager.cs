using System;
namespace MyGame
{
	public class DeploymentManager
	{
		public DeploymentManager ()
		{
		}
		public Unit Deloy (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				Town town = new Town ();
				return town;
			case UnitType.Mage:
				Mage mage = new Mage ();
				return mage;
			case UnitType.Ninja:
				Ninja ninja = new Ninja ();
				return ninja;
			case UnitType.Healer:
				Healer healer = new Healer ();
				return healer;
			case UnitType.Warrior:
				Warrior warrior = new Warrior ();
				return warrior;
			default:
				return null;
			}
		}
	}
}
