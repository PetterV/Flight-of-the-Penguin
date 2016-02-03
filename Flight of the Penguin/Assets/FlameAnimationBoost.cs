using UnityEngine;
using System.Collections;

public class FlameAnimationBoost : MonoBehaviour {

	private Animator animator;
	public int BoostOn = 5;
	public int BoostOff = 10;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Kicks off if boost is active
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime < BoostOn) {
			animator.SetInteger("FlameAnim", 1);
		}
		//Makes it stop after boost
		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > BoostOff) {
			animator.SetInteger("FlameAnim", 0);
		}
		else if (this.transform.parent.GetComponent<Movement>().jetpackOn == false) {
			animator.SetInteger("FlameAnim", 0);
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			animator.SetInteger("FlameAnim", 0);
		}
	}
}
