using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


	public float yShift = -20f; // Shift between the camera and the ball on the y-axis

	public GameObject target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y = target.transform.position.y + yShift;
		transform.position = pos;
	}

}
