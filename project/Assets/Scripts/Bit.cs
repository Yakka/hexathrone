using UnityEngine;
using System.Collections;

public class Bit : MonoBehaviour {

	public int bpm;
	public double bitStamp;
	public double bit;

	public double t = 0f;

	public Transform obj;

	// Use this for initialization
	void Start () {
		if (bpm != 0)
			bitStamp = 60.0f / bpm;
		bit = 0f;

		t = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
/*
		if (bit >= bitStamp) {
			bit -= bitStamp;
		}
		bit += Time.realtimeSinceStartup - t;

		t = Time.realtimeSinceStartup;
*/
		bit = audio.time % 2;

		obj.renderer.material.color = new Color(0.3f, (float) bit, (2 - (float) bit));

		obj.localScale = Vector3.one * (2 - (float) bit) * 3;

	}

	void OnGUI () {
		GUI.Label(new Rect(10, 20 + (float) bit * 30, 30, 30), "BIT");

		GUILayout.Label("Audio time: " + audio.time);
		GUILayout.Label("Bit   time: " + (int) bit);
	}
}
