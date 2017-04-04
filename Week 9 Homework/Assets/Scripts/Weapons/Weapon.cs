using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Weapon : MonoBehaviour {

	public virtual void fire
 	(float direction, 
		Vector3 modPos, 
		Vector3 size, 
		float Xspeed, 
		float Yspeed,
		float survive, 
		int damage, 
		string color,
		int owner){ 

		GameObject shot = Instantiate(Resources.Load("Prefabs/BladeBeam")) as GameObject;
		shot.transform.position = transform.position + modPos;
		shot.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((direction * Xspeed), direction * Yspeed);
		shot.GetComponent<BladeBeamBehavior> ().beamLimit = survive;
		shot.GetComponent<BladeBeamBehavior> ().beamDamage = damage;
		shot.GetComponent<BladeBeamBehavior> ().owner = owner;
		shot.transform.localScale = size; 
		if (direction == 1) 
		{
			shot.GetComponent<SpriteRenderer> ().flipX = false;
		}
		if (direction == -1) 
		{
			shot.GetComponent<SpriteRenderer> ().flipX = true; 
		}


		if (color == "White") 
		{
			shot.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255);
		}

		if (color == "Red") 
		{
			shot.GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0);
		}

		if (color == "Green") 
		{
			shot.GetComponent<SpriteRenderer> ().color = new Color (0, 255, 0);
		}
			
		if (color == "Blue") 
		{
			shot.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 255);
		}

	}
}
