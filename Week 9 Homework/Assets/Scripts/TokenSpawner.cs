using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour {

	public GameObject rockToken;
	public GameObject paperToken;
	public GameObject scissorsToken; 
	private Vector2 randomLocation; 
	public float minX;
	public float maxX; 
	public float minY;
	public float maxY; 
	public bool rockGone;
	public int rockTimer;
	public bool paperGone; 
	public int paperTimer;
	public bool scissorsGone; 
	public int scissorsTimer; 
	public int timerLimit;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		randomLocation = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY)); 

		if (rockGone == true) 
		{
			rockTimer++; 
		}
		if (paperGone == true) 
		{
			paperTimer++;
		}
		if (scissorsGone == true) 
		{
			scissorsTimer++;
		}

		if (rockTimer >= timerLimit) 
		{
			Instantiate (rockToken, randomLocation, Quaternion.identity);
			rockGone = false;
			rockTimer = 0;
		}

		if (paperTimer >= timerLimit) 
		{
			Instantiate (paperToken, randomLocation, Quaternion.identity);
			paperGone = false;
			paperTimer = 0;
		}


		if (scissorsTimer >= timerLimit) 
		{
			Instantiate (scissorsToken, randomLocation, Quaternion.identity);
			scissorsGone = false;
			scissorsTimer = 0;
		}
		
		
	}
}
