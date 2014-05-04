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

	public bool isHold;
	public float holdQuota;

	public int bonus = 1;

	public Track track;

	public GameObject effect;

	public UIPlayTween tween;

	private bool isExit;

	private float holdCounter;

	private Collider2D _ball;

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
		//	if ( isHold )
		//		gameObject.SetActive( false );
		}

		if ( isExit && InputManager.instance.m_isTapped )
		{
			ComputeQuota();

			isExit = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
    	if (other.gameObject.tag == "Ball") {
		
    		if(!destroying) {

					//TEMP Code !!
					if( InputManager.instance.m_isTapped ) 
					{
						CollectPowerup( other, transform.position );
						ActivateEffect();
					}
			}
		}
    }

	void OnTriggerEnter2D( Collider2D other )
	{
		//exit hold :D
		if ( isHold )
			Debug.Log( other.tag + " exited hold " );
	}

    private void PlayRandomSound(AudioClip[] sounds) {
    	audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length)], 1f);
    }

	void CollectPowerup( Collider2D ball, Vector3 position )
	{
		PlayRandomSound(rewardSounds);

		//transform.parent.parent.parent.parent.parent.parent.parent.BroadcastMessage("AddScore", bonus); // Dirty code is dirty.
		//we collide with the ball silly :P	
		ball.gameObject.SendMessage( "AddScore", bonus );
		
		track.IncrementeTrackScore();
		destroying = true;
		
		ParticleManager.instance.PlayParticle( "Hit", position );
	}

	void HoldEnter( Collider2D ball )
	{
		holdCounter = Time.time;
	}

	void HoldExit( Collider2D ball )
	{
		isExit = true;

		_ball = ball;
	}

	void ComputeQuota()
	{
		float quota = InputManager.instance.m_isTapped ? Time.time - InputManager.instance.m_holdCounter : 0f; //don't consider use if not released before
		float hold  = Time.time - holdCounter;
		
		float gaussian = Mathf.Exp( -0.5f * Mathf.Pow( quota - hold, 2 ) );
		if ( gaussian > holdQuota )
		{
			CollectPowerup( _ball, _ball.transform.position );
			ActivateEffect();
		}
	}

	void ActivateEffect()
	{
		if ( isHold )
		{
			tween.Play( true );
		}
		else
		{
			//disable renderer
			renderer.enabled = false;
			effect.SetActive( true );
		}
	}

	public void DestroyPowerUp()
	{
		gameObject.SetActive( false );
	}
}
