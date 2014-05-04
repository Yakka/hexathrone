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

	private float m_triggerCounter;


	// Use this for initialization
	void Start () {
	
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
		if ( other.tag.Equals( "Ball" ) && m_isTriggerPressed ) {
			StartCoroutine( DisableWallColliders( m_colliders ) );
		}
	}

	IEnumerator DisableWallColliders( Collider2D[] colliders )
	{
		foreach( Collider2D collider in colliders )
			collider.enabled = false;
		
		yield return new WaitForSeconds( m_wallColliderDelay );
		
		foreach( Collider2D collider in colliders )
			collider.enabled = true;

		
	}

	void Press()
	{
		m_isTriggerPressed = true;

		m_triggerCounter = Time.time;
	}
}
