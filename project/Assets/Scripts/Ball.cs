using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float horizontalSpeed = 100f;
	public float verticalSpeed = 100f;
	public float baseAccel = 10f;
	public float width = 21.65f;

	private int score = 0;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private float origin = 0f;
	private float percent;
	private float elapsedTime = 0f;
	public float debug = 50f;

	private bool isGoingToLeft = true;

	public Transform cachedTransform
	{
		get
		{
			if ( _cachedTransform == null )
				_cachedTransform = transform;

			return _cachedTransform;
		}
		set
		{
			_cachedTransform = value;
		}
	}

	private Transform _cachedTransform;

	public float input = 0f;

	// Use this for initialization
	void Start () {
		elapsedTime = Time.realtimeSinceStartup;
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);

		
	}

	private bool triggerGate = false;
	void Update () {
	
		// ---Manage Inputs---
		//input = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (triggerGate)
				Debug.Log("< Left");
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (triggerGate)
				Debug.Log("Right >");
		}
	}
	
	void FixedUpdate () {
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);
		Vector3 pos = cachedTransform.localPosition;
		float update = Time.deltaTime;
		percent = (100f - (origin / width) * 100f);
		
		Vector3 speed;
		if (isGoingToLeft) {
			cachedTransform.Rotate (new Vector3(0, 0, debug) * update * percent);
			speed = speedVectorLeft;
		} else {
			cachedTransform.Rotate (new Vector3(0, 0, -debug) * update * percent);
			speed = speedVectorRight;
		}
		speed.x *= percent * Time.deltaTime;
		pos += speed * Time.deltaTime;
		origin += Mathf.Abs(cachedTransform.localPosition.x - pos.x);
		cachedTransform.localPosition = pos;
	}

	public Color color;
	void OnTriggerEnter2D(Collider2D other) {
		bool reset = false;
		switch (other.tag) {
			case "Wall":
				isGoingToLeft = !isGoingToLeft;
				reset = true;
			break;
			case "Gate":
				triggerGate = true;
				reset = true;
			break;
		}
		if (reset) {
			//this.renderer.material.color = color;
			//Debug.Log(origin);
			//Debug.Log(Time.realtimeSinceStartup - elapsedTime);
			elapsedTime = Time.realtimeSinceStartup;
			origin = 0f;
		}
	}

	

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "gate") {
			triggerGate = false;
		}
	}

	public void InitializeScore() {
		score = 0;
	}

	public void AddScore(int bonus) {
		score += bonus;
	}
}
