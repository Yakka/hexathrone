using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour 
{
	//consider the gate opens to the right otherwise
	public bool m_isLeftTrigger;
	public bool m_isTriggerPressed;

	public float m_wallColliderDelay;
	public float m_triggerDelay;

	public Collider2D[] m_colliders;

	//locks gate passing to one time only D:
	private bool m_isTriggered;

	private float m_triggerCounter;

	public static AudioSource source;

	void Awake()
	{
		if ( source == null )
		{
			GameObject sourceGo = new GameObject();
			source = sourceGo.AddComponent<AudioSource>();

			source.clip = Resources.Load<AudioClip>( "Sounds/gate" );
			source.volume = 0.2f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//after delay is over 
		if ( Time.time - m_triggerCounter > m_triggerDelay )
			m_isTriggerPressed = false;

		bool trigger = m_isLeftTrigger ? InputManager.instance.m_isLeft : InputManager.instance.m_isRight;
		if ( !m_isTriggerPressed && trigger )
			Press();
	
	}

	void OnTriggerStay2D( Collider2D other ) 
	{ 
		if ( other.tag.Equals( "Ball" ) )
		{
			Ball theBall = other.GetComponent<Ball>(); //try to match the same direction of the ball
			if ( theBall.isLeft == m_isLeftTrigger && m_isTriggerPressed && !m_isTriggered )
			{
				StartCoroutine( DisableWallColliders( m_colliders ) );

				//launch particle
				ParticleManager.instance.PlayParticle( "Gate", transform.position );

				theBall.Transition( m_isLeftTrigger ? -1 : 1 );

				//Play sound
			//	if ( source != null )
			//		source.Play();
			}
		}
	}

	IEnumerator DisableWallColliders( Collider2D[] colliders )
	{
		m_isTriggered = true;

		foreach( Collider2D collider in colliders )
			collider.enabled = false;
		
		yield return new WaitForSeconds( m_wallColliderDelay );
		
		foreach( Collider2D collider in colliders )
			collider.enabled = true;
		m_isTriggered = false;
	}

	void Press()
	{
		m_isTriggerPressed = true;

		m_triggerCounter = Time.time;
	}
}
