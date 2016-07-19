using UnityEngine;
using System.Collections;

public class JetpackSound : MonoBehaviour {
	GameObject player ;
	float Fuel;
	//bool jetpackActive = false;
	public AudioClip audioClip;
	public AudioClip deadBurn;
	bool fuelPlaySound;// Use this for initialization
	bool hasPlayed = false;
	public bool levelDone = false;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		 //GetComponent<Movement>().fuelPlaySound;
		//Fuel =(int) player.GetComponent<Movement>().Fuel;
		Fuel = player.GetComponent<Movement> ().Fuel;
		if (player.GetComponent<Movement> ().paused == false ) {
			if (Input.GetButton ("Fire1") && Fuel > 0 && !levelDone ) {
				audio.clip = audioClip;
				if (!audio.isPlaying) {
					audio.loop = true;
					audio.Play ();
					hasPlayed = true;
				}
			} else if (Input.GetButton ("Fire1") && Fuel <= 0 && !levelDone ) {
				audio.clip = deadBurn;
				if (!audio.isPlaying) {
					audio.loop = false;
					audio.Play ();
					hasPlayed = true;
				}
			} else {
				audio.loop = false;
				if (hasPlayed) {
					StartCoroutine (VolumeFade (audio, 0f, 0.1f));
					hasPlayed = false;
						           
				}
			}
		}
	}

	IEnumerator VolumeFade(AudioSource _AudioSource, float _EndVolume, float _FadeLength)
	{
		
		float _StartVolume = _AudioSource.volume;
		
		float _StartTime = Time.time;
		
		while (Time.time < _StartTime + _FadeLength)
		{
			
			_AudioSource.volume = _StartVolume + ((_EndVolume - _StartVolume) * ((Time.time - _StartTime) / _FadeLength));
			
			yield return null;
			
		}
		
		if (_EndVolume == 0) {_AudioSource.Stop();}
		_AudioSource.volume = _StartVolume;
		
	}

}
