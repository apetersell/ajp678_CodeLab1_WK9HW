using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : Weapon {

	public override void fire
	(float direction, 
		Vector3 modPos, 
		Vector3 size, 
		float Xspeed, 
		float Yspeed,
		float survive, 
		float damage, 
		string color){ 

		base.fire (1, new Vector3 (0, 1, 0), size, 0, 20, 7, 2, "Red");
		base.fire (1, new Vector3 (0, -1, 0), size, 0, -20, 7, 2, "Red");
		base.fire (direction, modPos, size, 20, Yspeed, 7, 2, "Red");
		base.fire ((direction * -1), new Vector3 (-1, 0, 0), size, 20, Yspeed, 7, 2, "Red");
	}
}
