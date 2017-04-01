using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSUI : MonoBehaviour {

	public GameObject player;
	public Sprite rockUI;
	public Sprite paperUI;
	public Sprite scissorsUI;
	public Color rockColor;
	public Color paperColor;
	public Color scissorsColor; 
	RPSSystem rps;
	Image i;
	public int UINum;


	// Use this for initialization
	void Start () {
		rps = player.GetComponent<RPSSystem> ();
		i = GetComponent<Image> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (UINum == 1) 
		{
			if (rps.rock == true) {
				i.color = rockColor;
			}

			if (rps.paper == true) {
				i.color = paperColor;
			}

			if (rps.scissors == true) {
				i.color = scissorsColor;
			}
		}
		if (UINum == 2) 
		{
			if (rps.rock == true) {
				i.color = rockColor;
				i.sprite = rockUI;
			}

			if (rps.paper == true) {
				i.color = paperColor;
				i.sprite = paperUI;
			}

			if (rps.scissors == true) {
				i.color = scissorsColor;
				i.sprite = scissorsUI;
			}

		}
	}
}
