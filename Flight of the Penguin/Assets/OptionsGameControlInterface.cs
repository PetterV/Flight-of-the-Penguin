﻿using UnityEngine;
using System.Collections;

public class OptionsGameControlInterface : MonoBehaviour {

	public GameObject gameControl;
	public bool isMuted = false;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindWithTag("GameController");
		isMuted = gameControl.GetComponent<GameControl>().mute;
	}

	public void VolumeChange (float value){
		gameControl.GetComponent<GameControl>().soundVolume = value;
		GameObject.FindWithTag ("GameMusic").GetComponent<AudioSource>().volume = value;
	}

	public void EffectVolumeChange (float value){
		gameControl.GetComponent<GameControl>().effectVolume = value;
	}

	//void MuteOnOff (){
	//	if (isMuted == false ){
	//		isMuted = true;
	//		gameControl.GetComponent<GameControl>().mute = true;
	//	}
	//}
}
