using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(610,10,200,30), "Restart Level"))
		{
			
			Application.LoadLevel (Application.loadedLevelName);
			
		}
	}
}
