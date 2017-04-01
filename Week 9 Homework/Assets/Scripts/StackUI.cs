using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackUI : MonoBehaviour {

	public GameObject firstSlot;
	public GameObject secondSlot;
	public GameObject thirdSlot;
	public Sprite nadaUI; 
	public Sprite rockUI;
	public Sprite paperUI;
	public Sprite scissorsUI;
	Image firstImage;
	Image secondImage;
	Image thirdImage;
	RPSSystem rps;

	// Use this for initialization
	void Start () {

		firstImage = firstSlot.GetComponent<Image> ();
		secondImage = secondSlot.GetComponent<Image> ();
		thirdImage = thirdSlot.GetComponent<Image> ();
		rps = GetComponent<RPSSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
			
		
	}

	void firstSlotCheck()
	{
		string topCard = rps.currentHand.Peek ();
		if (topCard == "Rock") 
		{
			firstImage.sprite = rockUI; 
		}
		if (topCard == "Paper") 
		{
			firstImage.sprite = paperUI;
		}

		if (topCard == "Scissors") 
		{
			firstImage.sprite = scissorsUI; 
		}
			
			
	}

	void secondSlotCheck ()
	{
		secondImage.sprite = firstImage.sprite;
		Invoke ("firstSlotCheck", 1);
	}

	public void thirdSlotCheck()
	{
		thirdImage.sprite = secondImage.sprite;
		Invoke ("secondSlotCheck", 1);
	}

	public void unloadTheDeck()
	{
		firstImage.sprite = secondImage.sprite;
		secondImage.sprite = thirdImage.sprite;
		thirdImage.sprite = nadaUI;
	}
}
