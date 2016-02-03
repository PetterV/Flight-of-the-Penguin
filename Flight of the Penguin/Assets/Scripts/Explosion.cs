using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	GameObject player ;
	float Fuel;
	bool dead;
	public AudioClip explosion;
	float timeLeft = 3.0f;
	private bool playedExplosion = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		Fuel = player.GetComponent<Movement> ().Fuel;
		dead = player.GetComponent<Movement>().dead;
		audio.clip = explosion;
		if(Fuel < 1)
		{

			if(timeLeft < 0 && !audio.isPlaying)
			{
				//play explosions and 2 sec later restart?
				//print ("Explosion!");
				audio.Play();
				//dead = true;
				//spriteChanger.ChangeTheDamnSprite(deathSprite);
			}
		}

		if(dead == true && playedExplosion == false)
		{
			playedExplosion = true;
				//play explosions and 2 sec later restart?
				//print ("Explosion!");
				audio.Play();
				//dead = true;
				//spriteChanger.ChangeTheDamnSprite(deathSprite);
		}
	
	}
}
