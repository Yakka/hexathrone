using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	private int trackScore = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementeTrackScore() {
		trackScore ++;
		Debug.Log(trackScore);
	}
}
