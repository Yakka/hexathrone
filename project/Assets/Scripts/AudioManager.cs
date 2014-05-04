using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] channels;
	public bool muteAtStart = true;

	public GameObject channelPrefab; // Prefab to instatiate

	public AudioSource[] AC;

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
				tmpAC[i].mute = muteAtStart;
				tmpAC[i].Play();
				AC[chanNB] = tmpAC[i];
				chanNB ++;
			}
		}


	}

	public bool IsPlayingSomething() {
		foreach(AudioSource ac in AC) {
			if(ac.isPlaying && ac.mute == false) {
				return true;
			}
		}
		return false;
	}

	public void SwitchChannel(int chanID) {
		AudioSource ac = (AudioSource)transform.GetChild(chanID).GetComponent<AudioSource>();
		if(ac != null)
			ac.mute = !ac.mute;
		else
			Debug.Log("Error: invalid channel index.");
	}

	public void UnmuteAll() {
		int i = 0;
		AudioSource ac = null;
		do{
			ac = (AudioSource)transform.GetChild(i).GetComponent<AudioSource>();
			if(ac != null)
				ac.mute = false;
			else
				Debug.Log("Error: invalid channel index.");
			i ++;
		} while(ac != null);
	}

	public void MuteAll() {
		int i = 0;
		AudioSource ac = null;
		do{
			ac = (AudioSource)transform.GetChild(i).GetComponent<AudioSource>();
			if(ac != null)
				ac.mute = true;
			else
				Debug.Log("Error: invalid channel index.");
			i ++;
		} while(ac != null);
	}

	public void MuteChannel(int i) {
		if(i >= 0 && i < AC.Length)
			AC[i].mute = true;
	}

	public void UnmuteChannel(int i) {
		if(i >= 0 && i < AC.Length)
			AC[i].mute = false;
		else Debug.Log("!! i = "+i);
	}

}
