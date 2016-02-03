using UnityEngine;
using System.Collections;

public class OlafSigh : MonoBehaviour {
	public AudioClip sigh;
	GameObject player;
	bool hasFlown= false;
	float time = 1.0f;
	bool dead;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		dead = player.GetComponent<Movement> ().dead;
		if (Input.GetButtonDown("Fire1" ) && dead == false) {
			hasFlown = true;
			time = 1.0f;
		}
		if (hasFlown == true) {
			if (player.rigidbody2D.velocity.x == 0 && player.rigidbody2D.velocity.y == 0) {
				time -= Time.deltaTime;
				if (time <= 0){
					audio.PlayOneShot(sigh);
					hasFlown=false;
					time = 1.0f;
				}
			}

		}

	}
}
