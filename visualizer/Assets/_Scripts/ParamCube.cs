using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
	public int _band;
	public float _startScale, _scaleMultiplier;
	public bool _useBuffer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform the size based on audio parameters and public attributes defined above
		if (_useBuffer) {
			transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._bandBuffer [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		}

		if (!_useBuffer) {
			transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._freqBand [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		}


		transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) * _startScale, transform.localScale.z);
	}
}
