using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y = target.transform.position.y;
		transform.position = pos;
	}
}
