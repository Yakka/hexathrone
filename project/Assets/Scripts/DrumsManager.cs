using UnityEngine;
using System.Collections;

public class DrumsManager : MonoBehaviour {

	private AudioManager AM;

	public Track[] targets;

	void Start () {
		AM = gameObject.GetComponent<AudioManager>();
		AM.SetVolumeChannel(1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		int nb = 0;
		foreach(Track tr in targets) {
			if(tr.IsPlayingSomething())
				nb++;
		}

		if(nb > 3) {
			AM.SetVolumeAll(0f);
			AM.SetVolumeChannel(1f, 2);
		}
		else if(nb > 1){
			AM.SetVolumeAll(0f);
			AM.SetVolumeChannel(1f, 1);
		} else {
			AM.SetVolumeAll(0f);
			AM.SetVolumeChannel(1f, 0);
		}
	}
}
