using UnityEngine;
using System.Collections;

public class CameraManager : Base 
{
	public float yShift = -20f; // Shift between the camera and the ball on the y-axis

	public GameObject target;

	private Transform m_cachedTargetTransform;

	void Start()
	{
		//cache target transform
		m_cachedTargetTransform = target.transform;
	}

	void Update() 
	{
		Vector3 pos = cachedTransform.localPosition;

		//work in local position to maintain pixel units
		pos.y = m_cachedTargetTransform.localPosition.y + yShift;
		cachedTransform.localPosition = pos;
	}
}
