using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongShot : Weapon {

	public override void fire
	(float direction, 
		Vector3 modPos, 
		Vector3 size, 
		float Xspeed,
		float Yspeed,
		float survive, 
		float damage, 
		string color){ 

		base.fire (direction, modPos, size, 30, Yspeed, 40, 3, "Blue");

	}
}
