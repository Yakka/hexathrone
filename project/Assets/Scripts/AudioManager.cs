using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] channels;

	public GameObject channelPrefab; // Prefab to instatiate

	// Use this for initialization
	void Start () {

		// Instantiate the different channels
		foreach(AudioClip ac in channels) {
			GameObject channel = (GameObject)Instantiate(channelPrefab);
			channel.transform.parent = transform;
			channel.name = "Channel";
		}

		AudioSource[] AC = gameObject.GetComponentsInChildren<AudioSource>();
		for(int i = 0; i < channels.Length; i++) {
			AC[i].clip = channels[i];
		}

		foreach(AudioSource ac in AC) {
			ac.Play();
		}

		//AC[0].mute = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
