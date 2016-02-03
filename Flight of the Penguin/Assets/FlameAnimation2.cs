using UnityEngine;
using System.Collections;

public class FlameAnimation2 : MonoBehaviour {

	private Animator animator;
	private int jetpackFlame2OffTimer = 0;
	public int jetpackFlame2OffAmount = 10;
	public int jetpackFlame2KickIn = 100;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Kicks off if boost is active
//		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime < 10) {
//			animator.SetInteger("FlameAnim", 1);
//			jetpackFlame2OffTimer = jetpackFlame2OffAmount;
//		}
		//Makes it stop after boost
//		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > 10 && this.transform.parent.GetComponent<Movement>().jetpackOnTime < jetpackFlame2KickIn) {
//			animator.SetInteger("FlameAnim", 0);
//			jetpackFlame2OffTimer = jetpackFlame2OffAmount;
//		}
		//Kicks off after boost, if rocket time is reached
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > jetpackFlame2KickIn) {
			animator.SetInteger("FlameAnim", 1);
			jetpackFlame2OffTimer = jetpackFlame2OffAmount;
		}
		//Reduces jetpackFlame2OffTimer
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == false) {
			jetpackFlame2OffTimer--;
		}
		//Turns animation off when engine is off
		if (jetpackFlame2OffTimer < 1) {
			animator.SetInteger("FlameAnim", 0);
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			animator.SetInteger("FlameAnim", 0);
		}
	}
}
