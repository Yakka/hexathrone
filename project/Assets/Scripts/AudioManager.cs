using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] channels;
	public bool muteAtStart = true;

	public GameObject channelPrefab; // Prefab to instatiate

	private AudioSource[] AC;

	// Use this for initialization
	void Start () {

		// Instantiate the different channels
		for(int i = 0; i < channels.Length; i++) {
			GameObject channel = (GameObject)Instantiate(channelPrefab);
			channel.transform.parent = transform;
			channel.name = "Channel"+name;
		}

		AudioSource[] tmpAC = gameObject.GetComponentsInChildren<AudioSource>();
		AC = new AudioSource[channels.Length];
		int chanNB = 0;
		for(int i = 0; i < tmpAC.Length; i++) {
			if(chanNB >= channels.Length)
				break;
			else if(tmpAC[i].gameObject.name == "Channel"+name) {
				tmpAC[i].clip = channels[chanNB];
				if(muteAtStart)
					tmpAC[i].volume = 0f;
				tmpAC[i].Play();
				AC[chanNB] = tmpAC[i];
				chanNB ++;
			}
		}


	}

	public bool IsPlayingSomething() {
		foreach(AudioSource ac in AC) {
			if(ac.isPlaying && ac.mute == false && ac.volume > 0f) {
				return true;
			}
		}
		return false;
	}

	public void SetVolumeAll(float v) {
		foreach(AudioSource ac in AC) {
			ac.volume = v;
		}
	}

	public void SetVolumeChannel(float v, int id) {
		if(id >= 0 && id < AC.Length)
			AC[id].volume = v;
	}

	public void ReduceVolumeAll(float v) {
		foreach(AudioSource ac in AC) {
			if(ac.volume > v)
				ac.volume = v;
		}
	}

}
