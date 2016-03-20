using UnityEngine;
using System.Collections;

public class GoalCelebration : MonoBehaviour {

	//Fish Objects
	public GameObject fish1;
	public GameObject fish2;
	public GameObject fish3;
	public GameObject fish4;
	bool notHit = true;
	bool completed = false;
	GameObject gameMusic;
	
	void Awake () {
		fish1.particleSystem.enableEmission = false;
		fish2.particleSystem.enableEmission = false;
		fish3.particleSystem.enableEmission = false;
		fish4.particleSystem.enableEmission = false;
		gameMusic = GameObject.FindWithTag ("GameMusic");

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && notHit) {
			completed = true;
			print ("Goal!");
			notHit = false;
			//Trigger particle fishies
			fish1.particleSystem.enableEmission = true;
			fish2.particleSystem.enableEmission = true;
			fish3.particleSystem.enableEmission = true;
			fish4.particleSystem.enableEmission = true;
			gameMusic.GetComponent<Persistence>().FadeMusic();
		}
		
	}
}
