using UnityEngine;
using System.Collections;

public class ButtonSounds : MonoBehaviour {

	AudioSource audio;
	public AudioClip goLeftButtonSound;
	public AudioClip goRightButtonSound;
	public AudioClip startButtonSound;
	public AudioClip backButtonSound;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void PlaySound (AudioClip sound) {
		audio.PlayOneShot(sound);
	}
}
