using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public int highscore = 0;

	public GameObject highscoreGO;
	private UILabel highscoreScript;

	// Use this for initialization
	void Start () {

		highscoreScript = highscoreGO.GetComponent<UILabel>();

		if (PlayerPrefs.HasKey("Highscore")) {
			highscore = PlayerPrefs.GetInt("Highscore");
		}
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
		StartCoroutine(fuckit2());
	}

	public GameObject playUI;
	public GameObject howtoUI;
	public GameObject creditsUI;

	public void LoadHowTo() {
		StartCoroutine(fuckit());

	}

	IEnumerator fuckit() {
		playUI.SetActive(false);
		howtoUI.SetActive(true);

		yield return new WaitForSeconds(3);

		howtoUI.SetActive(false);
		playUI.SetActive(true);
	}

	IEnumerator fuckit2() {
		playUI.SetActive(false);
		creditsUI.SetActive(true);

		yield return new WaitForSeconds(3);

		creditsUI.SetActive(false);
		playUI.SetActive(true);
	}
}
