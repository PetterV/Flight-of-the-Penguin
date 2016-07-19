using UnityEngine;
using System.Collections;

public class OptionsGameControlInterface : MonoBehaviour {

	public GameObject gameControl;
	public bool isMuted = false;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindWithTag("GameController");
		isMuted = gameControl.GetComponent<GameControl>().mute;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void VolumeChange (float value){
		gameControl.GetComponent<GameControl>().soundVolume = value;
	}

	//void MuteOnOff (){
	//	if (isMuted == false ){
	//		isMuted = true;
	//		gameControl.GetComponent<GameControl>().mute = true;
	//	}
	//}
}
