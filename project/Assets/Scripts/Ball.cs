using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float horizontalSpeed = 100f;
	public float verticalSpeed = 100f;
	public float timeStick = 750f;
	public float baseAccel = 10f;
	public float width = 21.65f;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private float origin = 0f;
	private float weight;
	private float percent;
	public float debug = 50f;

	private bool isGoingToLeft = true;

	private bool isSticking = false;
	private float timerSticking = 0f;

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
		weight = 0.2f; // (width / horizontalSpeed) * 1.3f;
		Debug.Log (weight);
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);

		
	}

	private bool triggerGate = false;
	void Update () {
		if(isSticking) {
			timerSticking += Time.deltaTime;
			if(timerSticking >= timeStick)
				isSticking = false;
		}
	
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
		Vector3 pos = cachedTransform.position;
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
		origin += Mathf.Abs(cachedTransform.position.x - pos.x);
		cachedTransform.position = pos;
	}

	public Color color;
	void OnTriggerEnter2D(Collider2D other) {
		switch (other.tag) {
			case "Wall": {
				isGoingToLeft = !isGoingToLeft;
				this.renderer.material.color = color;
				origin = 0f;
			} break;
			case "Gate": {
				triggerGate = true;
				this.renderer.material.color = color;
				origin = 0f;
			}
			break;
		}
    }

    void OnTriggerStay2D(Collider2D other) {
    	if (other.gameObject.name == "PowerUp") {
			bool destroy = false;
			#if UNITY_ANDROID
				//TEMP Code !!
				if(Input.GetKey(KeyCode.Space)) {
					destroy = true;
				}
				// Swipe!
			#else
				// COPY PASTE HERE FOR WINDOWS BUILD
			#endif

			if(destroy)
				Destroy(other.gameObject);

		}
    }

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "gate") {
			triggerGate = false;
		}
	}
}
