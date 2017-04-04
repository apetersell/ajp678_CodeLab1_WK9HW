using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBeamBehavior : MonoBehaviour {

	public float beamTimer; 
	public float beamLimit; 
	public int beamDamage;
	public int owner;
	GameObject bossMeter;  


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		beamTimer++;
		if (beamTimer >= beamLimit) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Floor")
		{
			Destroy (gameObject);
		}

	}

}
