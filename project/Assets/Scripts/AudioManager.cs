using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] channels;

	public GameObject channelPrefab; // Prefab to instatiate

	// Use this for initialization
	void Start () {

		// Instantiate the different channels
		for(int i = 0; i < channels.Length; i++) {
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

	}

	public void Update() {

	}

	public void SwitchChannel(int chanID) {
		AudioSource ac = (AudioSource)transform.GetChild(chanID).GetComponent<AudioSource>();
		if(ac != null)
			ac.mute = !ac.mute;
		else
			Debug.Log("Error: invalid channel index.");
	}

}
