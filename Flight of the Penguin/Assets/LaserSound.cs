using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour {
	public GameObject laserBeam;
	public GameObject warmUpBeam;
	AudioSource audioSource;
	public bool fadeDown = false;
	public bool returnVolume = true;
	public bool mainLaserPlaying = false;
	bool paused = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (warmUpBeam.activeSelf){
			fadeDown = false;
			returnVolume = true;
		}
		if (laserBeam.activeSelf) {
			mainLaserPlaying = true;
		}
		if(!laserBeam.activeSelf && !warmUpBeam.activeSelf){
			fadeDown = true;
			returnVolume = false;
			mainLaserPlaying = false;
		}
		if (fadeDown == true && audioSource.volume > 0){
			audioSource.volume = audioSource.volume - 0.2f;
		}
		if (fadeDown == true && audioSource.volume <= 0) {
			audioSource.Stop();
		}
		if (returnVolume == true && audioSource.volume < 0.2f) {
			audioSource.volume = 0.3f;
		}
		if (returnVolume == true && audioSource.volume > 0.2f && !audioSource.isPlaying) {
			audioSource.Play ();
		}
		if (mainLaserPlaying && audioSource.volume < 1f) {
			audioSource.volume = 1f;
		}
	}
}
