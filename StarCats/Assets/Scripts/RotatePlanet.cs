﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{

	public float rotationsPerMinute; //= 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0, 2.0f*rotationsPerMinute*Time.deltaTime);
		
	}
}
