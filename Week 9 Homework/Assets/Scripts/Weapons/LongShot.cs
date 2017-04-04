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
		int damage, 
		string color,
		int owner){ 

		base.fire (direction, modPos, new Vector3 (.25f, .25f, .25f), 30, Yspeed, 40, 3, "Blue", owner);

	}
}
