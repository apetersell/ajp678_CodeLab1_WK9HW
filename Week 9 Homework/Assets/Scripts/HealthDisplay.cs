using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	public Text scoreBoard;
	PlayerMovement pm;
	Text t;

	// Use this for initialization
	void Start () {
		pm = GetComponent <PlayerMovement> ();
		t = scoreBoard.GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		t.text = pm.health.ToString (); 
		
	}
}
