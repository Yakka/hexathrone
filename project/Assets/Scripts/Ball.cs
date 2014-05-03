using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float horizontalSpeed = 5f;
	public float verticalSpeed = 5f;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private bool isGoingToLeft = true;

	// Use this for initialization
	void Start () {
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);
	}
	
	void FixedUpdate () {
		Vector3 pos = transform.position;
		if(isGoingToLeft)
			pos += speedVectorLeft * Time.deltaTime;
		else
			pos += speedVectorRight * Time.deltaTime;
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other) {
		isGoingToLeft = !isGoingToLeft;
    }
}
