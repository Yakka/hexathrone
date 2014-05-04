using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public static InputManager instance { get { return m_instance; } }

	private static InputManager m_instance;

	public bool m_isLeft;
	public bool m_isRight;
	public bool m_isTapped; //see if we synch with note

	public float m_swipeThreshold;
	public float m_clickDelay;

	public float m_holdCounter;

	private bool m_isHold;
	
	private float m_clickCounter;
	void Awake()
	{
		if ( m_instance == null )
			m_instance = this;
		else
			Destroy( this );
	}

	void Update()
	{
#if UNITY_EDITOR || ( !UNITY_ANDROID && !UNITY_IPHONE )

		m_isLeft  = Input.GetButtonUp( "Left" );
		m_isRight = Input.GetButtonUp( "Right" );

		m_isTapped = Input.GetButtonUp( "Tap" );

		m_isHold = Input.GetButton( "Tap" );

		if ( Input.GetButtonDown( "Tap" ) )
			m_holdCounter = Time.time;
#else

		if ( Time.time - m_clickCounter > m_clickDelay )
		{
			m_isTapped = false;

			m_isRight = false;
			m_isLeft  = false;
		}
#endif
	}

	void LateUpdate()
	{
		//reset hold
		if ( !m_isHold )
			m_holdCounter = Time.time;
	}

	void OnDrag( Vector2 delta )
	{
		float drag = delta.x;
	
		if ( Mathf.Abs( drag ) > m_swipeThreshold )
		{
			if   ( drag > 0 ) m_isRight = true;
			else              m_isLeft  = true;

			m_clickCounter = Time.time;
		}
	}

	void OnClick()
	{
		m_isTapped = true;

		m_clickCounter = Time.time;
	}

	void OnPress( bool isPress )
	{
		m_isHold = isPress;
		if ( isPress )
			m_holdCounter = Time.time;
	}


}
