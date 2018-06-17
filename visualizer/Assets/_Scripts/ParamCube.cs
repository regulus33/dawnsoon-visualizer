﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
	public int _band;
	public float _startScale, _scaleMultiplier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform the size based on audio parameters and public attributes defined above
		transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) * _startScale, transform.localScale.z);
	}
}
