using UnityEngine;
using System.Collections;

public class MenuBg : MonoBehaviour {

	public Color color;
	private HSBColor _bgColor;

	public float speed;

	public float h;
	public float s;
	public float b;

	private UISprite bg;

	// Use this for initialization
	void Start () {
		bg = GetComponent<UISprite>();

		_bgColor = new HSBColor(color);
	}
	
	// Update is called once per frame
	void Update () {

		h = _bgColor.h;
		s = _bgColor.s;
		b = _bgColor.b;

		_bgColor.h += Time.deltaTime / 100 * speed;

		if (_bgColor.h > 1)
			_bgColor.h = 0;

		transform.Rotate(0, 0, Time.deltaTime * speed);

		color = _bgColor.ToColor();
		bg.color = color;
	}
}
