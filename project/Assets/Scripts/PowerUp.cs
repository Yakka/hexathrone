using UnityEngine;
using System.Collections;


public class PowerUp : MonoBehaviour {

	public enum PowerType {
		Left,
		Right
	};

	public PowerType powerType = PowerType.Left;

	// Use this for initialization
	void Start () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();

		switch(powerType) {
			case PowerType.Left:
				sprite.sprite = Resources.Load<Sprite>("leftPower");
			break;
			case PowerType.Right:
				sprite.sprite = Resources.Load<Sprite>("rightPower");
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
