using UnityEngine;
using System.Collections;

public class ParticleSortingLayer : MonoBehaviour {

	public string SortingLayer;

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Player";
		
	}
}
