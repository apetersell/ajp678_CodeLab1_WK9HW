using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static int galScore;
	public static int guyScore;
	public int maxTime;
	private int btsTimer;
	public int framesPerUnit;
	public int displayedTimer;
	public static ScoreManager scoreCard; 
	public KeyCode restart;
	public bool canReset;

	// Use this for initialization
	void Start () {

		displayedTimer = maxTime;

		if (scoreCard == null){ 
			scoreCard = this;  
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}
	}
		
	
	// Update is called once per frame
	void Update () {

		handleTimer ();

		if (canReset == true) 
		{
			if (Input.GetKeyDown (restart)) 
			{
				guyScore = 0;
				galScore = 0;
				canReset = false;
				displayedTimer = maxTime;
				SceneManager.LoadScene (2);
			}
		}
	}

	public void scorePoints (int sentValue)
	{
		if (sentValue == 1) 
		{
			galScore++;
		}

		if (sentValue == 2) 
		{
			guyScore++;
		}
	}

	public void subtractPoints (int sentValue)
	{
		if (sentValue == 1) 
		{
			galScore --;
		}

		if (sentValue == 2) 
		{
			guyScore--;
		}
	}

	void handleTimer ()
	{
		if (canReset == false) 
		{
			btsTimer++;
			if (btsTimer >= framesPerUnit) {
				displayedTimer--;
				btsTimer = 0;
			}
		}

		if (displayedTimer < 0 && canReset == false) 
		{
			canReset = true;
			if (galScore > guyScore) {
				SceneManager.LoadScene ("Player Gal Wins");
			}
				
			if (guyScore > galScore) {
				SceneManager.LoadScene ("Player Guy Wins");
			}
		}
	}
}
