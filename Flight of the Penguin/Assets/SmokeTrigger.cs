using UnityEngine;
using System.Collections;

public class SmokeTrigger : MonoBehaviour {


	private int jetpackFlameOffTimer = 0;
	public int jetpackFlameOffAmount = 10;
	

	// Update is called once per frame
	void Update () {
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > 3) {
			this.GetComponent<ParticleSystem>().enableEmission = true;
			jetpackFlameOffTimer = jetpackFlameOffAmount;
		}
		if (this.transform.parent.GetComponent<Movement> ().jetpackOn == false) {
			jetpackFlameOffTimer--;
		}
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == false && jetpackFlameOffTimer < 1){
			this.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			this.GetComponent<ParticleSystem>().enableEmission = false;
		}
	}
}
