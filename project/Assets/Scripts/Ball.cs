using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float horizontalSpeed = 5f;
	public float verticalSpeed = 5f;
	public float timeStick = 750f;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private bool isGoingToLeft = true;

	private bool isSticking = false;
	private float timerSticking = 0f;

	// Use this for initialization
	void Start () {
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);
	}

	void Update() {
		if(isSticking) {
			timerSticking += Time.deltaTime;
			if(timerSticking >= timeStick)
				isSticking = false;
		}
	}
	
	void FixedUpdate () {
		if(!isSticking) {
			Vector3 pos = transform.position;
			if(isGoingToLeft)
				pos += speedVectorLeft * Time.deltaTime;
			else
				pos += speedVectorRight * Time.deltaTime;
			transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		isGoingToLeft = !isGoingToLeft;
		timerSticking = 0f;
		isSticking = true;
    }
}
