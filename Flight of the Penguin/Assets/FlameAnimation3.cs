using UnityEngine;
using System.Collections;

public class FlameAnimation3 : MonoBehaviour {

	private Animator animator;
	private int jetpackFlame3OffTimer = 0;
	public int jetpackFlame3OffAmount = 10;
	public int jetpackFlame3KickIn = 80;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Kicks off if boost is active
//		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime < 10) {
//			animator.SetInteger("FlameAnim", 1);
//			jetpackFlame3OffTimer = jetpackFlame3OffAmount;
//		}
		//Makes it stop after boost
//		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > 10 && this.transform.parent.GetComponent<Movement>().jetpackOnTime < jetpackFlame3KickIn) {
//			animator.SetInteger("FlameAnim", 0);
//			jetpackFlame3OffTimer = jetpackFlame3OffAmount;
//		}
		//Kicks off after boost, if rocket time is reached
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > jetpackFlame3KickIn) {
			animator.SetInteger("FlameAnim", 1);
			jetpackFlame3OffTimer = jetpackFlame3OffAmount;
		}
		//Reduces jetpackFlame2OffTimer
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == false) {
			jetpackFlame3OffTimer--;
		}
		//Turns animation off when engine is off
		if (jetpackFlame3OffTimer < 1) {
			animator.SetInteger("FlameAnim", 0);
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			animator.SetInteger("FlameAnim", 0);
		}
	}
}
