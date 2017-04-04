using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShot : Weapon {

	public override void fire
	(float direction, 
		Vector3 modPos, 
		Vector3 size, 
		float Xspeed, 
		float Yspeed,
		float survive, 
		float damage, 
		string color){ 

		base.fire (direction, modPos, new Vector3 (0.5133314f, 0.5133314f, 0.5133314f), 2.5f, Yspeed, 60, 5, "Green");

	}
}
