using UnityEngine;
using System.Collections;

public class TheBstScript : MonoBehaviour {

    public float val; // sound level - dB
    public float max = 11;
    public float min = -130;
    public Color baseColor;

    private float[] samples; // audio samples
    private float fSample;
    private AudioSource aud;
     
    public UISprite _sprite;
	// Use this for initialization
	void Start () {
        AudioSource[] AC = transform.parent.GetComponent<AudioManager>().GetAudioSources();
        _sprite = GetComponentsInChildren<UISprite>()[0];
        baseColor = _sprite.color;
        samples = new float[1];
        aud = AC[0];
        aud.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
        aud.GetOutputData(samples, 0); // fill array with samples
        val = 20f * Mathf.Log10( samples[0] / 0.1f ); // calculate dB
        val = Mathf.Clamp(val, -200f, 200f);
        if (double.IsNaN(val) && val < -160f) {
            val = -160f; // clamp it to -160dB min
            _sprite.color = Color.black;
        }
        else {
            if (val > max) {
                max = val;
            }
            else if (val < min) {
                min = val;
            }
            val = (max + min) / (val + min);
            _sprite.color = baseColor;
            //_sprite.color = Color.Lerp(Color.black, baseColor, val);
        }
	
	}
}
