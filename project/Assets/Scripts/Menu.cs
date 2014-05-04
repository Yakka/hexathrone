using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public int highscore = 0;

	public GameObject highscoreGO;
	private UILabel highscoreScript;

	// Use this for initialization
	void Start () {

		//PlayerPrefs.SetInt("Highscore", 0);

		highscoreScript = highscoreGO.GetComponent<UILabel>();

		if (PlayerPrefs.HasKey("Highscore"))
			highscore = PlayerPrefs.GetInt("Highscore");
		else
			highscore = 0;
		highscoreScript.text = "HIGHSCORE\n" + highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadGame() {
		Application.LoadLevel("Game");
	}

	public void LoadCredits() {
		//Application.LoadLevel("Credits");
	}

	public void LoadHowTo() {
		//Application.LoadLevel("Howto");
	}
}
