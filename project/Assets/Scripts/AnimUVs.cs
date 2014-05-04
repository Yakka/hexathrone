using UnityEngine;
using System.Collections;

public class AnimUVs : MonoBehaviour 
{
	public Vector2 m_speed;

	public UITexture m_texture;

	void Update()
	{
		Rect uvs = m_texture.uvRect;

		uvs.x = ( uvs.x + m_speed.x * Time.deltaTime ) % 2;
		uvs.y = ( uvs.y + m_speed.y * Time.deltaTime ) % 2;

		m_texture.uvRect = uvs;
	}
}

