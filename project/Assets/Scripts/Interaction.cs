using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour 
{
	void OnClick()
	{
	}

	void OnPress( bool over )
	{
		if ( over )
		{
			Debug.Log( "Clicked over" );
		}
		else
			Debug.Log( "Release" );
	}

	void OnDrag( Vector2 delta )
	{
		Debug.Log( delta );
	}

	void OnHover( bool isOver )
	{
		Debug.Log( "Hovered" );
	}
}
