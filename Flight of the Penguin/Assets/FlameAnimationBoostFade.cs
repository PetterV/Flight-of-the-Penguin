using UnityEngine;
using System.Collections;

public class FlameAnimationBoostFade : MonoBehaviour {

	private Animator animator;
	private int BoostFadeCounter = 0;
	public int BoostFadeTime = 10;

	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Kicks off if boost is active
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime < 10) {
			BoostFadeCounter = BoostFadeTime;
		}
		//Makes it stop after boost
		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > 10) {
			BoostFadeCounter--;
		}
		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == false) {
			BoostFadeCounter--;
		}
		if (BoostFadeCounter > 1 && this.transform.parent.GetComponent<Movement> ().jetpackOn == true && this.transform.parent.GetComponent<Movement> ().jetpackOnTime > 10) {
			animator.SetInteger ("FlameAnim", 1);
		}
		if (BoostFadeCounter < 1) {
			animator.SetInteger ("FlameAnim", 0);
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			animator.SetInteger("FlameAnim", 0);
		}
	}
}