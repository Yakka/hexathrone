using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	private int trackScore = 0;
	public int neededScoreToPlay = 1;

	private AudioManager audioTarget;

	// Use this for initialization
	void Start () {
		audioTarget = gameObject.GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if(trackScore >= neededScoreToPlay) {
			audioTarget.UnmuteAll();
		}
	}

	public void IncrementeTrackScore() {
		trackScore ++;
		
	}
}
