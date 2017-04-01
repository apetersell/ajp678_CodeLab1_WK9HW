using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSSystem : MonoBehaviour {

	public int playerNum;
	public int handNumber;
	public bool rock;
	public Color rockColor;
	public bool paper;
	public Color paperColor;
	public bool scissors;
	public Color scissorsColor;
	public GameObject rockBlock;
	public GameObject paperBlock;
	public GameObject scissorsBlock; 
	public GameObject hitbox;
	public KeyCode shift;
	public KeyCode create;
	public KeyCode destroy;
	public int shiftCooldown;
	public int shiftCooldownLimit;
	public bool canShift = true;
	public Stack <string> currentHand = new Stack <string> ();
	public int maxStackSize;
	public int currentStackSize;
	StackUI sui;

	GameObject scoreManager;
	ScoreManager sm;
	Hitbox hb;
	SpriteRenderer sr;
	SpriteRenderer hbsr; 

	// Use this for initialization
	void Start () {

		hb = hitbox.GetComponent<Hitbox> (); 
		hbsr = hitbox.GetComponent<SpriteRenderer> (); 
		sr = GetComponent<SpriteRenderer> ();
		handNumber = Random.Range (1, 3);
		scoreManager = GameObject.Find("Score Manager");
		sm = scoreManager.GetComponent<ScoreManager> ();
		sui = GetComponent<StackUI> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		handHandler ();
		visiuals ();
		rpsShiftController ();
		createBlock ();



		hb.handNumber = handNumber;

		
	}


	void handHandler ()
	{
		if (handNumber == 1) 
		{
			rock = true;
			paper = false;
			scissors = false;
		}
		if (handNumber== 2) 
		{
			rock = false;
			paper = true;
			scissors = false;;
		}
		if (handNumber == 3) 
		{
			rock = false;
			paper = false;
			scissors = true;
		}

		if (handNumber > 3) 
		{
			handNumber = 1;
		}
	}

	void visiuals ()
	{
		if (rock) 
		{
			sr.color = rockColor;
			hbsr.color = rockColor;
			hbsr.sprite = hb.rockSprite; 

		}
		if (paper) 
		{
			sr.color = paperColor;
			hbsr.color = paperColor;
			hbsr.sprite = hb.paperSprite; 

		}

		if (scissors) 
		{
			sr.color = scissorsColor;
			hbsr.color = scissorsColor;
			hbsr.sprite = hb.scissorsSprite; 
		}
	}

	void rpsShiftController ()
	{
		if (canShift == true) 
		{
			if (Input.GetKeyDown (shift)) 
			{
				string loadUp = currentHand.Pop (); 
				if (loadUp == "Rock") 
				{
					handNumber = 1;
					currentStackSize--; 
				}
				if (loadUp == "Paper") 
				{
					handNumber = 2;
					currentStackSize--;
				}
				if (loadUp == "Scissors") 
				{
					handNumber = 3;
					currentStackSize--;
				}
				canShift = false;
				sui.unloadTheDeck ();
			}
		}

		if (canShift == false) 
		{
			shiftCooldown++; 
		}

		if (shiftCooldown >= shiftCooldownLimit) 
		{
			canShift = true;
			shiftCooldown = 0;
		}

	}

	void createBlock ()
	{
		if (Input.GetKeyDown (create)) 
		{
			if (rock == true) 
			{
				Instantiate (rockBlock, hb.transform.position, Quaternion.identity);
			}

			if (paper == true) 
			{
				Instantiate (paperBlock, hb.transform.position, Quaternion.identity); 
			}

			if (scissors == true) 
			{
				Instantiate (scissorsBlock, hb.transform.position, Quaternion.identity);
			}
			sm.scorePoints (playerNum);
		}
	}

	public void addToStack (string sentString)
	{
		if (currentStackSize < maxStackSize) 
		{
			currentHand.Push (sentString);
			currentStackSize++; 
		}
	}
}
