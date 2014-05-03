using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public static InputManager instance { get { return m_instance; } }

	private static InputManager m_instance;

	public bool m_isLeft;
	public bool m_isRight;

	public float m_swipeThreshold;

	void Awake()
	{
		if ( m_instance == null )
			m_instance = this;
		else
			Destroy( this );
	}

	void Update()
	{
		m_isLeft  = Input.GetButtonUp( "Left" );
		m_isRight = Input.GetButtonUp( "Right" );
	}

	void OnDrag( Vector2 delta )
	{
		float drag = delta.x;
		if ( Mathf.Abs( drag ) > m_swipeThreshold )
		{
			if   ( drag > 0 ) m_isRight = true;
			else              m_isLeft  = true;
		}
	}
}
