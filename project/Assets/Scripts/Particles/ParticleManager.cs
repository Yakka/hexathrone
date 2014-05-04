using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour 
{
	public Transform m_particleParent;

	public static ParticleManager instance { get { return m_instance; } }

	private static ParticleManager m_instance;

	void Awake()
	{
		if ( m_instance == null )
			m_instance = this;
		else
			Destroy( this );
	}

	public void PlayParticle( string particleName, Vector3 position )
	{
		GameObject particlePrefab = Resources.Load<GameObject>( "Particles/" + particleName );
		GameObject particle       = Instantiate( particlePrefab ) as GameObject;

		Transform cachedTransform = particle.transform;

		cachedTransform.parent     = m_particleParent;
		cachedTransform.position   = position;
		cachedTransform.localScale = Vector3.one;

	}

}
