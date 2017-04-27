using System;
namespace MyGame
{
	public class DeploymentManager
	{
		public DeploymentManager ()
		{
		}
		public void Deloy (UnitType type) { 
			switch(type){ 
				case UnitType.Town:
				//
				//draw()
				//Move()
				break;
			case UnitType.Mage:
				break;
			case UnitType.Ninja:
				break;
			case UnitType.Healer:
				break;
			case UnitType.Warrior:
				break;
			default:
				//Class not found
				break;
			}
		}
	}
}
