using UnityEngine;
using System.Collections;

public class Adjust : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (GUI.Button (new Rect (10, 100, 100, 40), "Collect")) {
			GameControl.control.level1 = true;
		}
	}
}
