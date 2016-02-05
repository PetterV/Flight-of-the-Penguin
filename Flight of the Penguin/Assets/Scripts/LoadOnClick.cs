using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	public GameObject loadingScreen;
	// Use this for initialization

	public float pageWidth = 500;
	public float buttonTransitionSpeed = 10;

	public void LoadScene(int level)
	{

		if (GameControl.control && (level != 0 && level != 1 && level != 2 && level != 3)) {
			print ("Load game level " + level);
			if (GameControl.control.CheckLevelClear (level - 1)) {
				if (loadingScreen)
					loadingScreen.SetActive (true);

				Application.LoadLevel (level);
			}
		} else if (level == 0 || level == 1 || level == 2 || level == 3) {
			print ("Load menu level " + level);
			if (loadingScreen)
				loadingScreen.SetActive (true);
			
			Application.LoadLevel (level);
		} else {
			print(level);
		}

		/*
		print ("Load menu level " + level);
		if (loadingScreen)
			loadingScreen.SetActive (true);
		Application.LoadLevel (level);
		*/
	}

	public void LoadFromUIButton(int levelToLoad)
	{
		print ("Load game level " + levelToLoad);
		LoadWithDelay (levelToLoad);
	}

	IEnumerator LoadWithDelay (int levelToLoad)
	{
		yield return new WaitForSeconds (1f);
		Application.LoadLevel (levelToLoad);
	}
}
