using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	GameObject[] musicObject;

	public static int levelMusic = 0;

	// Use this for initialization
	void Start () {
		musicObject = GameObject.FindGameObjectsWithTag ("GameMusic");
		if (musicObject.Length == 1 ) {
			audio.Play ();
		}
//		else {
//			for(int i = 1; i < musicObject.Length; i++){
//				Destroy(musicObject[i]);
//			}
//			
//		}
//		
//		
	}
	
	// Update is called once per frame
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

//	void OnLevelWasLoaded(int level) {
//		print (level);
//		if (level == 0 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("pianovalse");
//			audio.Play ();
//			levelMusic = 0;
//		}
//		else if (level == 1 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("pianovalse");
//			audio.Play ();
//			levelMusic = 1;
//		}
//		else if (level == 2 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Loopbar_chill_soundtrack");
//			audio.Play ();
//			levelMusic = 2;
//		}
//		else if (level == 3 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Spontan");
//			audio.Play ();
//			levelMusic = 3;
//		}
//		else if (level == 4 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Neeo");
//			audio.Play ();
//			levelMusic = 4;
//		}
//		else if (level == 5 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("rasmus_pingvinlyder_remixxxxxx");
//			audio.Play ();
//			levelMusic = 5;
//		}
//		else if (level == 6 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Loopbar_rask_dataspill");
//			audio.Play ();
//			levelMusic = 6;
//		}
//		else if (level == 7 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Uneducate_loopbar");
//			audio.Play ();
//			levelMusic = 7;
//		}
//		else if (level == 8 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Neeo");
//			audio.Play ();
//			levelMusic = 8;
//		}
//		else if (level == 9 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Uneducate_loopbar");
//			audio.Play ();
//			levelMusic = 9;
//		}
//		else if (level == 10 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("rasmus_pingvinlyder_remixxxxxx");
//			audio.Play ();
//			levelMusic = 10;
//		}
//		else if (level == 11 && level != levelMusic) {
//			audio.clip = (AudioClip)Resources.Load ("Spontan");
//			audio.Play ();
//			levelMusic = 11;
//		}
//	}
	
}