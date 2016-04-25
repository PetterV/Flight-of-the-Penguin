using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public int levelToLoad;
	public string sceneToLoad;
	// Use this for initialization
	
	// Update is called once per frame
	public void LoadLevelFromInt(int levelToLoad){
		Application.LoadLevel (levelToLoad);
	}

	public void LoadLevelFromName(string sceneToLoad){
		Application.LoadLevel (sceneToLoad);
	}
}
