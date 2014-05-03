using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class Grid : MonoBehaviour {

	private Vector3 startingPos1;
	private Vector3 startingPos2;
	private Vector3 startingPos2V;

	public float interval = 1.0f;
	public int lines = 20;
	public int horizontalSeparators = 5;
	public int verticalSeparators = 5;
	public Color colorLines;
	public Color colorHSeparators;
	public Color colorVSeparators;

	public bool ouchMyEyes = false;
	
	private UISprite bg;
	// Use this for initialization
	void Start () {
		startingPos1 = new Vector3(-0.625f, 1, 0);
		startingPos2 = new Vector3(0.625f, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bg = GetComponent<UISprite>();

		startingPos2V = new Vector3(-0.625f, 1 - (interval * lines), 0);

		DrawGrid();

		if (ouchMyEyes)
			bg.enabled = true;
		else
			bg.enabled = false;
	}

	void DrawGrid() {

		//Horizontal lines
		float deltaHSep = interval / (horizontalSeparators + 1);
		
		for (int i = 0; i < lines; i++) {
			Vector3 offset = new Vector3(0, i * interval, 0);
			
			Debug.DrawLine(startingPos1 - offset, startingPos2 - offset, colorLines);

			for (int j = 1; j < horizontalSeparators + 1; j++) {
				
				Vector3 sepHOffset = new Vector3(0, j * deltaHSep, 0);

				Debug.DrawLine(startingPos1 - offset - sepHOffset,
							   startingPos2 - offset - sepHOffset,
							   colorHSeparators);
			}
		}

		//Vertical Lines
		float deltaVSep = 800 * 0.0015625f / verticalSeparators;
		
		for (int k = 0; k < verticalSeparators + 1; k++) {

			Vector3 sepVOffset = new Vector3(k * deltaVSep, 0, 0);

			Debug.DrawLine(startingPos1 + sepVOffset, startingPos2V + sepVOffset, colorVSeparators);
		}
	}
}
