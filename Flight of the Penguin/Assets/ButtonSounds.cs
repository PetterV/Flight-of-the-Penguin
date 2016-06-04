using UnityEngine;
using System.Collections;

public class ButtonSounds : MonoBehaviour {

	AudioSource audio;
	public AudioClip goLeftButtonSound;
	public AudioClip goRightButtonSound;
	public AudioClip startButtonSound;
	public AudioClip backButtonSound;
	//public GameObject gameControl;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		//gameControl = GameObject.FindWithTag ("GameControl");
	}
	
	// Update is called once per frame
	public void PlaySound (AudioClip sound) {
		//if (gameControl.GetComponent<LoadOnClick> ().canMoveOnButton == true) {
			audio.PlayOneShot (sound);
		//}
	}
}
