using UnityEngine;
using System.Collections;

public class TriggerMessage : MonoBehaviour 
{
	public string m_tag;
	public string m_message;

	public GameObject m_target;

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.tag.Equals( m_tag ) )
			m_target.SendMessage( m_message, other );
	}
}
