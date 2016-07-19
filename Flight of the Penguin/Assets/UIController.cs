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

	// Use this for initialization
	void Awake () {
		reallyMenu = GameObject.FindWithTag ("ReallyMenu");
		reallyQuit = GameObject.FindWithTag ("ReallyQuit");
		reallySelect = GameObject.FindWithTag ("ReallySelect");
		wantsToQuit = false;
		wantsToMenu = false;
		wantsToSelect = false;
		player = GameObject.FindWithTag ("Player");
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
}
