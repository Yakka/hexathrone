using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 5f;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private bool isGoingToLeft = true;

	// Use this for initialization
	void Start () {
		speedVectorLeft = -Vector3.up*0.5f*Mathf.PI - Vector3.right*0.5f*Mathf.PI;
		speedVectorRight = -Vector3.up*0.5f*Mathf.PI + Vector3.right*0.5f*Mathf.PI;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if(isGoingToLeft)
			pos += speedVectorLeft * Time.deltaTime * speed;
		else
			pos += speedVectorRight * Time.deltaTime * speed;
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other) {
		isGoingToLeft = !isGoingToLeft;
    	Debug.Log("pouet");
    }
}
