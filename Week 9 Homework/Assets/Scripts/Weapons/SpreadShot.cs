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
		int damage, 
		string color,
		int owner){ 

		base.fire (1, new Vector3 (0, 1, 0), size, 0, 20, 7, 2, "Red", owner);
		base.fire (1, new Vector3 (0, -1, 0), size, 0, -20, 7, 2, "Red", owner);
		base.fire (direction, modPos, size, 20, Yspeed, 7, 2, "Red", owner);
		base.fire ((direction * -1), new Vector3 (-1, 0, 0), size, 20, Yspeed, 7, 2, "Red", owner);
	}
}
