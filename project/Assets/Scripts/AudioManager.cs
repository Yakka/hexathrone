using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] channels;

	// Use this for initialization
	void Start () {
		/*Channel chan = new Channel();
		for(int i = 0; i < channels.Length; i++) {
			Channel c = Instantiate(chan, transform, quaternion);
			c.audioSource.audioClip = channels[i];
		}
		*/
		AudioSource[] AC = gameObject.GetComponentsInChildren<AudioSource>();
		for(int i = 0; i < channels.Length; i++) {
			AC[i].clip = channels[i];
		}

		foreach(AudioSource ac in AC) {
			ac.Play();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
