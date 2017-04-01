using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

	public int otherPlayerNum; 
	public Vector3 flippedPos;
	public Vector3 nonFlippedPos;
	PlayerMovement pm;
	public bool rock;
	public bool paper;
	public bool scissors;
	public Sprite rockSprite;
	public Sprite paperSprite;
	public Sprite scissorsSprite;
	public int handNumber;
	BlockShtuffs bs; 
	GameObject scoreManager;
	ScoreManager sm;


	// Use this for initialization
	void Start () {

		pm = GetComponentInParent<PlayerMovement> ();
		scoreManager = GameObject.Find("Score Manager");
		sm = scoreManager.GetComponent<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		orientation ();
		handHandler ();
		
	}

	void orientation ()
	{
		if (Input.GetKeyDown(pm.left)) 
		{
			transform.localPosition = flippedPos;

		}

		if (Input.GetKeyDown(pm.right)) 
		{
			transform.localPosition = nonFlippedPos;
		}
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

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Block") 
		{
			GameObject touchedBlock = coll.gameObject;
			BlockShtuffs bs = touchedBlock.GetComponent<BlockShtuffs> ();
			if (bs.rock == true && paper == true) 
			{
				Destroy (coll.gameObject);
				if (bs.ownerNum == otherPlayerNum) 
				{
					sm.subtractPoints (otherPlayerNum);
				}
			}

			if (bs.paper == true && scissors == true) 
			{
				Destroy (coll.gameObject);
				if (bs.ownerNum == otherPlayerNum) 
				{
					sm.subtractPoints (otherPlayerNum);
				}
			}

			if (bs.scissors == true && rock == true) 
			{
				Destroy (coll.gameObject);
				if (bs.ownerNum == otherPlayerNum) 
				{
					sm.subtractPoints (otherPlayerNum);
				}
			}
		}
	}
}
