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

	public int bonus = 1;

	public Track track;

	// Use this for initialization
	void Start () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		/*
		switch(powerType) {
			case PowerType.Left:
				sprite.sprite = Resources.Load<Sprite>("leftPower");
			break;
			case PowerType.Right:
				sprite.sprite = Resources.Load<Sprite>("rightPower");
			break;
		}
		*/

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

					//TEMP Code !!
					if( InputManager.instance.m_isTapped ) 
					{
						PlayRandomSound(rewardSounds);
						//transform.parent.parent.parent.parent.parent.parent.parent.BroadcastMessage("AddScore", bonus); // Dirty code is dirty.
						//we collide with the ball silly :P	
						other.gameObject.SendMessage( "AddScore", bonus );
						
						track.IncrementeTrackScore();
						destroying = true;
			
						ParticleManager.instance.PlayParticle( "Hit", transform.position );
					}
			}
		}
    }

    private void PlayRandomSound(AudioClip[] sounds) {
    	audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length)], 1f);
    }
}
