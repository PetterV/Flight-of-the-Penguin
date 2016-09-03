using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {
	public GameObject loadingScreen;
	// Use this for initialization

	public float buttonTransitionSpeed = 10;
	public int numOfPages = 5;
	public int currentPage = 0;
	public GameObject leftButtontoEnable;
	public GameObject rightButtontoEnable;

	//Holding areas for pages
	public GameObject holdingAreaLeft;
	public GameObject holdingAreaCenter;
	public GameObject holdingAreaRight;
	public float buttonWait = 30.0f;
	public float buttonTimer = 0.0f;
	public bool canMoveOnButton = true;

	void Update (){
		if (buttonTimer > 0) {
			buttonTimer++;
			if(buttonTimer > buttonWait){
				buttonTimer = 0.0f;
				canMoveOnButton = true;
			}
		}
	}

	public void LoadScene(int level)
	{

		if (GameControl.control && (level != 0 && level != 1 && level != 2 && level != 3)) {
			print ("Load game level " + level);
			//if (GameControl.control.CheckLevelClear (level - 1)) {
				if (loadingScreen)
					loadingScreen.SetActive (true);

				Application.LoadLevel (level);
			//}
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

	public void IncreaseCurrentPage(){
		if (canMoveOnButton) {
			buttonTimer = 1f;
			canMoveOnButton = false;
			if (currentPage < numOfPages) {
				currentPage++;
			}
		}
		leftButtontoEnable.GetComponent<Button> ().interactable = true;
		if (currentPage == numOfPages) {
			rightButtontoEnable.GetComponent<Button>().interactable = false;
		}
	}

	public void DecreaseCurrentPage(){
		if (canMoveOnButton){
			buttonTimer = 1f;
			canMoveOnButton = false;
			if (currentPage > 0){
				currentPage--;
			}
		}
		rightButtontoEnable.GetComponent<Button> ().interactable = true;
		if (currentPage < 1) {
			leftButtontoEnable.GetComponent<Button>().interactable = false;
		}
	}

	public void LoadFromUIButton(int levelToLoad)
	{
		print ("Load game level " + levelToLoad);
		LoadWithDelay (levelToLoad);
	}

	IEnumerator LoadWithDelay (int levelToLoad)
	{
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (levelToLoad);
	}
}
