using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject reallyQuit;
	public GameObject reallyMenu;
	public GameObject reallySelect;
	public GameObject player;
	public bool wantsToQuit = false;
	public bool wantsToMenu = false;
	public bool wantsToSelect = false;
	GameObject fuelStuff;
	GameObject timerBox;
	bool showUI = true;

	// Use this for initialization
	void Awake () {
		showUI = true;
		reallyMenu = GameObject.FindWithTag ("ReallyMenu");
		reallyQuit = GameObject.FindWithTag ("ReallyQuit");
		reallySelect = GameObject.FindWithTag ("ReallySelect");
		wantsToQuit = false;
		wantsToMenu = false;
		wantsToSelect = false;
		player = GameObject.FindWithTag ("Player");
		fuelStuff = GameObject.FindWithTag("FuelStuff");
		timerBox = GameObject.FindWithTag("TimerBox");
	}
	
	// Update is called once per frame
	void Update () {
		if (wantsToQuit == true) {
			reallyQuit.SetActive(true);
		}
		if (wantsToQuit == false) {
			reallyQuit.SetActive(false);
		}

		if (wantsToMenu == true) {
			reallyMenu.SetActive(true);
		}
		if (wantsToMenu == false) {
			reallyMenu.SetActive(false);
		}

		if (wantsToSelect == true) {
			reallySelect.SetActive(true);
		}
		if (wantsToSelect == false) {
			reallySelect.SetActive(false);
		}
		if ( Input.GetKeyDown(KeyCode.U)){
			UIOnOff();
		}
	}

	public void WantToQuit(){
		wantsToQuit = !wantsToQuit;
	}

	public void WantToMenu(){
		wantsToMenu = !wantsToMenu;
	}

	public void WantToSelect(){
		wantsToSelect = !wantsToSelect;
	}

	public void ActuallyQuit(){
		Application.Quit ();
		print ("Quit!");
	}

	public void LoadMenu(string menuName){
		Application.LoadLevel (menuName);
		print ("Load" + menuName);
	}

	public void UnpauseButton (){
		player.GetComponent<Movement>().Unpause();
	}

	public void UIOnOff (){
		if ( showUI ) {
			showUI = false;
			fuelStuff.SetActive(false);
			timerBox.SetActive(false);
		}
		else if ( !showUI ) {
			showUI = true;
			fuelStuff.SetActive(true);
			timerBox.SetActive(true);
		}
	}
}
