using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public int levelToLoad;
	public string sceneToLoad;
	private int buttonLevelToLoad;
	// Use this for initialization

	// Update is called once per frame
	public void LoadLevelFromInt(int levelToLoad){
		Application.LoadLevel (levelToLoad);
	}

	public void LoadLevelFromName(string sceneToLoad){
		Application.LoadLevel (sceneToLoad);
	}

	public void LoadNextLevel(){
		buttonLevelToLoad = GameObject.FindWithTag ("GameController").GetComponent<GameControl> ().level + 1;
		print ("I'm loading " + buttonLevelToLoad);
		Application.LoadLevel (buttonLevelToLoad);
	}
}
