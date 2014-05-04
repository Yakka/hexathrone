using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	private int trackScore = 0;
	public int neededScoreToPlay = 1;

	public int id;
	public Ball target;
	private int lastCrossedBar = 0;

	private AudioManager audioTarget;

	// Use this for initialization
	void Start () {
		audioTarget = gameObject.GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// The ball is not on the track and has crossed a bar
		if(target.crossedBars != lastCrossedBar && target.GetCurrentTrack() != id) {
			trackScore --;
		}
/*
		if(trackScore >= neededScoreToPlay) {
			audioTarget.UnmuteAll();
		}
		else {
			audioTarget.MuteAll();
		} */
		lastCrossedBar = target.crossedBars;
	}

	public void IncrementeTrackScore() {
		trackScore ++;
		
	}
}
