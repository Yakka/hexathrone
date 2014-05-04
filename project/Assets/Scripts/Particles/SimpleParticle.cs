using UnityEngine;
using System.Collections;

//the only thing this script does is destroy the particle prefab when it's animation finished D:
public class SimpleParticle : MonoBehaviour 
{
	public void SelfDestruct()
	{
		Destroy( gameObject );
	}
}
