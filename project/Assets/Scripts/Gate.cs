using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	private bool isTrigger = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		//isTrigger = true;
	
	}

	void OnTriggerExit2D(Collider2D other) {
		//isTrigger = false;
		
	}

}
