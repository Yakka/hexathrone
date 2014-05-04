using UnityEngine;
using System.Collections;

public class TheBstScript : MonoBehaviour {

    public float val; // sound level - dB
    public float max = 11f;
    public float min = -130f;
    public Color baseColor;

    private float[] samples; // audio samples
    private float fSample;
     
    public UISprite _sprite;
	// Use this for initialization
	void Start () {
        _sprite = GetComponent<UISprite>();
        baseColor = _sprite.color;
        samples = new float[1];
        fSample = AudioSettings.outputSampleRate;
        audio.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
        audio.GetOutputData(samples, 0); // fill array with samples
        val = 20f * Mathf.Log10( samples[0] / 0.1f ); // calculate dB
        if (val < -160f)
            val = -160f; // clamp it to -160dB min
        else {
            if (val > max) {
                max = val;
            }
            else if (val < min) {
                min = val;
            }
            val = (max + min) / (val + min);

            _sprite.color = Color.Lerp(Color.black, baseColor, val);
        }
	
	}
}
