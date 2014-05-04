using UnityEngine;
using System.Collections;

public class DrumsManager : MonoBehaviour {

	private AudioManager AM;

	public Track[] targets;

	void Start () {
		AM = gameObject.GetComponent<AudioManager>();
		AM.UnmuteChannel(0);
	}
	
	// Update is called once per frame
	void Update () {
		int nb = 0;
		foreach(Track tr in targets) {
			if(tr.IsPlayingSomething())
				nb++;
		}

		if(nb > 0)
			AM.UnmuteChannel(1);
		else
			AM.MuteChannel(1);

		if(nb > 3)
			AM.UnmuteChannel(2);
		else
			AM.MuteChannel(2);
	}
}
