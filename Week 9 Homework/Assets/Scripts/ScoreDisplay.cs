using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	Text t; 
	public int playerNum;
	GameObject scoreManager;
	ScoreManager sm;

	// Use this for initialization
	void Start () {

		t = GetComponent<Text> ();
		scoreManager = GameObject.Find ("Score Manager");
		sm = scoreManager.GetComponent<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (playerNum == 1) 
		{
			t.text = ScoreManager.galScore.ToString();
		}

		if (playerNum == 2) 
		{
			t.text = ScoreManager.guyScore.ToString();
		}

		if (playerNum == 3) 
		{
			t.text = sm.displayedTimer.ToString (); 
		}
		
	}
}
