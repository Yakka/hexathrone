using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	private int trackScore = 0;
	public int scoreToPlay = 1;
	public int scoreToStop = 1;

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
		if(target.crossedBars != lastCrossedBar && target.GetCurrentTrack() != id && trackScore > 0) {
			trackScore --;
		}
		/*
		if(trackScore >= scoreToPlay) {
			audioTarget.UnmuteAll();
		}
		else if(trackScore < scoreToStop) {
			audioTarget.MuteAll();
		} */
		lastCrossedBar = target.crossedBars;
		audioTarget.SetVolumeAll(Mathf.Clamp(((float) trackScore)/ ((float) scoreToPlay), 0f, 1f));
	}

	public bool IsPlayingSomething() {
		return audioTarget.IsPlayingSomething();
	}

	public void IncrementeTrackScore() {
		trackScore ++;
		
	}
}
