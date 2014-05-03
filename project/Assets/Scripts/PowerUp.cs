using UnityEngine;
using System.Collections;


public class PowerUp : MonoBehaviour {

	public enum PowerType {
		Left,
		Right
	};

	public PowerType powerType = PowerType.Left;

	private AudioSource audioSource;
	public AudioClip[] rewardSounds;

	private bool destroying = false;


	// Use this for initialization
	void Start () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();

		switch(powerType) {
			case PowerType.Left:
				sprite.sprite = Resources.Load<Sprite>("leftPower");
			break;
			case PowerType.Right:
				sprite.sprite = Resources.Load<Sprite>("rightPower");
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(destroying) {
			renderer.enabled = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
    	if (other.gameObject.name == "Ball") {
    		if(!destroying) {
				#if UNITY_ANDROID
					//TEMP Code !!
					if(Input.GetKeyDown(KeyCode.Space)) {
						PlayRandomSound(rewardSounds);
						transform.parent.parent.BroadcastMessage("AddScore", 1);
						destroying = true;
					GetComponent<ParticleSystem>().Play();
					}
					// Swipe!
				#else
					// COPY PASTE HERE FOR WINDOWS BUILD
				#endif
			}

		}
    }

    private void PlayRandomSound(AudioClip[] sounds) {
    	audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length)], 1f);
    }
}
