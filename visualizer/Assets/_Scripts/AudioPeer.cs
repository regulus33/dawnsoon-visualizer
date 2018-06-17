using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour {

	AudioSource _audioSource;
	public static float[] _samples = new float[512];
	public static float[] _freqBand = new float[8];

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () {
		GetSpectrumAudioSource ();
		MakeFrequencyBands ();
	}

	void GetSpectrumAudioSource() {
												//Blackman is an algo for efficient iteration?
		_audioSource.GetSpectrumData (_samples, 0, FFTWindow.Blackman); 
	}
		
	//we have a ton of frequency bands from 2 - 512, the math below allows us to escalate through these
	//bands in an equally divided way
	void MakeFrequencyBands() {
		int count = 0;
		float average = 0;

		for (int i = 0; i < 8; i++){
			int sampleCount = (int)Mathf.Pow(2,i) * 2;

			if (i == 7) {
				sampleCount += 2;
			}
			//now we must send our samples into our freq band.
			for (int j = 0; j < sampleCount; j++) {
				average += _samples [count] * (count + 1);
					count++;
			}

			average /= count;
			//				average is a bit below zero so we multiply by ten
			_freqBand [i] = average * 10;
		}
	}

}
