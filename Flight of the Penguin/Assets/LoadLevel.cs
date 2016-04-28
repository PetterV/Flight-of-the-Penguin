using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public int levelToLoad;
	public string sceneToLoad;
	private int buttonLevelToLoad;
	GameObject gameController;
	// Use this for initialization
	void Start (){
		gameController = GameObject.FindWithTag ("GameController");
	}

	// Update is called once per frame
	public void LoadLevelFromInt(int levelToLoad){
		Application.LoadLevel (levelToLoad);
	}

	public void LoadLevelFromName(string sceneToLoad){
		Application.LoadLevel (sceneToLoad);
	}

	public void LoadNextLevel(){
		buttonLevelToLoad = gameController.GetComponent<GameControl> ().level + 1;
		print ("I'm loading " + buttonLevelToLoad);
		Application.LoadLevel (buttonLevelToLoad);
	}
}
