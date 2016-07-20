using UnityEngine;
using System.Collections;

public class PlaySoundOnce : MonoBehaviour {

	AudioSource audio;
	public AudioClip sound;
	public bool onlyOnce = false;
	public float volume = 1.0f;
	bool hasPlayed = false;
	public bool mineMakeSound;
	public bool audioSourceInParent;
	public bool isMusic = false;

	void Start (){
		if (!audioSourceInParent) {
			audio = GetComponent<AudioSource> ();
		}
		if (audioSourceInParent) {
			audio = GetComponentInParent<AudioSource> ();
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player"){
			if ( isMusic ) {
				volume = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().volume;
			}
			audio.PlayOneShot(sound, volume);
			if (onlyOnce && !hasPlayed){
				hasPlayed = true;
			}
		}

		if (coll.gameObject.tag == "Mine" && mineMakeSound){
			if ( isMusic ) {
				volume = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().volume;
			}
			audio.PlayOneShot(sound, volume);
			if (onlyOnce && !hasPlayed){
				hasPlayed = true;
			}
		}
	}


	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Player"){
			if ( isMusic ) {
				volume = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().volume;
			}
			audio.PlayOneShot(sound, volume);
			if (onlyOnce && !hasPlayed){
				hasPlayed = true;
			}
		}
		
		if (coll.gameObject.tag == "Mine" && mineMakeSound){
			if ( isMusic ) {
				volume = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>().volume;
			}
			audio.PlayOneShot(sound, volume);
			if (onlyOnce && !hasPlayed){
				hasPlayed = true;
			}
		}
	}
}
