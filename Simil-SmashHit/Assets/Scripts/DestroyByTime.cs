﻿using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float delay;

	// Use this for initialization
	void Start () 
	{
	
		Destroy (gameObject,delay);
	}
	
}
