using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour 
{
	public Transform cachedTransform
	{
		get 
		{
			if ( m_cachedTransform == null )
				m_cachedTransform = transform;

			return m_cachedTransform;
		}
	}	

	private Transform m_cachedTransform;
}
