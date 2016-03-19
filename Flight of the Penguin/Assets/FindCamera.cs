using UnityEngine;
using System.Collections;

public class FindCamera : MonoBehaviour {

	Canvas uiCanvas;

	// Use this for initialization
	void Start () {
		uiCanvas = GetComponent<Canvas>();
		uiCanvas.worldCamera = Camera.main; 
	}

}
