﻿using UnityEngine;
using System.Collections;

public class ArrowLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Obstacle";
		particleSystem.renderer.sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
