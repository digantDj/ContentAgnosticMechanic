using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {

	public Text title;
	public Text domain;
	public Text description;
	public Text contentOneText;
	public Text contentTwoText;

	private int pulseDelay = 0;
	private const int DELAY = 15;

	private Content contentOne;
	private Content contentTwo;

	private string[] substrings;

	// Use this for initialization
	void Start()
	{
		// Change these in ContentList to each be one of your own content objects!
		contentOne = GameInfo.contentOne;
		contentTwo = GameInfo.contentTwo;

		// Change this to the title of your game in ContentList.
		title.text = GameInfo.gameTitle;

		// Set as a blank before the player selects one.
		//FrameworkCore.setContent(new NoContent());
		updateDisplay();
		PlayerPrefs.SetString("Diseases","");
		FileManagement.init(); // Create the dump file to mark the start of the game.
	}

	// Update is called once per frame
	void Update()
	{
		if(pulseDelay > 0)
		{
			pulseDelay--;
			description.color = Color.red;
		}
		else
		{
			description.color = Color.white;
		}
	}

	// Updates various pieces of text on the screen.
	private void updateDisplay()
	{
//		domain.text = FrameworkCore.currentContent.name;
		//description.text = FrameworkCore.currentContent.description;
		description.text = "";
		if (FrameworkCore.currentContent.name == "Health & Disease") {
			Debug.Log (PlayerPrefs.GetString ("Diseases"));
			substrings = PlayerPrefs.GetString ("Diseases").Split('\n');
			Debug.Log (PlayerPrefs.GetString ("Diseases"));
			HealthContent hcobj = new HealthContent ();
			foreach(string item in substrings)
			{
				if(item != " ")
				description.text += hcobj.getEntireTerm (item) + "\n";
			}
			// description.text = PlayerPrefs.GetString ("Diseases");
		}
		else if(FrameworkCore.currentContent.name == "Social Issues") {

			substrings = PlayerPrefs.GetString ("Diseases").Split('\n');

			SocialScienceContent sscobj = new SocialScienceContent ();
			foreach(string item in substrings)
			{
				if(item != " ")
					description.text += sscobj.getEntireTerm (item) + "\n";
			}
			// description.text = PlayerPrefs.GetString ("Diseases");
		}
		GameObject.FindWithTag ("Score").GetComponent<GUIText>().text = "Score: " + PlayerPrefs.GetInt("Player Score");
	}

	public void hitQuit()
	{
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
		else
		{
			Application.Quit();
		}
	}

	public void hitMenu()
	{
		// ... Clearing the storage variables
		PlayerPrefs.SetInt("Player Score", 0);

		SceneManager.LoadScene(0);
	}



}
