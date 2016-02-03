using UnityEngine;
using System.Collections;

public class ButtonQuitDesktop : MonoBehaviour {
	
	GameObject quitCanvas;

	void Start(){
		quitCanvas = GameObject.FindWithTag ("QuitOverlay");
		quitCanvas.SetActive (false);
	}

	public void AskToQuit(){
		quitCanvas.SetActive (true);
	}

	public void NotQuitting(){
		quitCanvas.SetActive (false);
	}

	public void Quit(){
			Application.Quit();
	}


}