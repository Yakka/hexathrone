using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float horizontalSpeed = 100f;
	public float verticalSpeed = 100f;
	public float timeStick = 750f;
	public float baseAccel = 10f;
	public float width = 19.2f;

	private Vector3 speedVectorLeft;
	private Vector3 speedVectorRight;

	private float origin = 0f;
	private float accel;
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




	// Use this for initialization
	void Start () {
		accel = baseAccel;
		weight = 0.2f; // (width / horizontalSpeed) * 1.3f;
		Debug.Log (weight);
		speedVectorLeft = new Vector3(-horizontalSpeed, -verticalSpeed, 0);
		speedVectorRight = new Vector3(horizontalSpeed, -verticalSpeed, 0);
	}

	void Update () {
		if(isSticking) {
			timerSticking += Time.deltaTime;
			if(timerSticking >= timeStick)
				isSticking = false;
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
		this.renderer.material.color = color;
		isGoingToLeft = !isGoingToLeft;
		//Debug.Log (transform.position);
		//Debug.Log (accel);
		Debug.Log (origin);
		origin = 0f;
		accel = baseAccel;
		//timerSticking = 0f;
		//isSticking = true;
    }
}
