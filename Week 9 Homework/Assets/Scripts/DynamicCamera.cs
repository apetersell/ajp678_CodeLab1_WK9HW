using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {


	GameObject playerGuy;
	GameObject playerGal;
	public float camZ;
	float camZoom;
	public float zoomLowerLim; 
	public float zoomUpperLim; 
	public float leftLimit;
	public float rightLimit;
	public float upperLimit;
	public float lowerLimit;


	// Use this for initialization
	void Start () {

		playerGal = GameObject.Find ("Player Gal");
		playerGuy = GameObject.Find ("Player Guy");
	}
	
	// Update is called once per frame
	void Update () {

		Camera.main.orthographicSize = camZoom;
		Vector3 midpoint = ((playerGal.transform.position - playerGuy.transform.position) * 0.5f) + playerGuy.transform.position;
		midpoint.z = camZ;
		Camera.main.transform.position = midpoint;
		camZoom = Vector3.Distance(playerGal.transform.position, playerGuy.transform.position);

		if (camZoom > zoomUpperLim) 
		{
			camZoom = zoomUpperLim;
		}

		if (camZoom < zoomLowerLim)
		{
			camZoom = zoomLowerLim;
		}

		if (midpoint.x > rightLimit) 
		{
			midpoint.x = rightLimit;
		}

		if (midpoint.x < leftLimit) 
		{
			midpoint.x = leftLimit;
		}

		if (midpoint.y > upperLimit) 
		{
			midpoint.y = upperLimit;
		}

		if (midpoint.y < lowerLimit) 
		{
			midpoint.y = lowerLimit;
		}
//		
	}
}
