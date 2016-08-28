using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public int levelToLoad;
	public string sceneToLoad;
	public int buttonLevelToLoad;
	//public GameObject gameController;
	//public int levelNumber;
	// Use this for initialization
	/*
	void Awake(){
		gameController = GameObject.FindWithTag ("GameController");
		levelNumber = gameController.GetComponent<GameControl> ().level;
	}
	*/

	// Update is called once per frame
	public void LoadLevelFromInt(int levelToLoad){
		Application.LoadLevel (levelToLoad);
	}

	public void LoadLevelFromName(string sceneToLoad){
		Application.LoadLevel (sceneToLoad);
	}

	public void LoadNextLevel(){
	//	print ("I'm loading " + buttonLevelToLoad);
		Application.LoadLevel (buttonLevelToLoad);
	}

	public void ThisLevelAgain() {
		Application.LoadLevel(Application.loadedLevelName);
	}
}
