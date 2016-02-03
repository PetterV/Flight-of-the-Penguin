using UnityEngine;
using System.Collections;

public class FlameAnimation1 : MonoBehaviour {

	private Animator animator;
	private int jetpackFlameOffTimer = 0;
	public int jetpackFlameOffAmount = 10;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == true && this.transform.parent.GetComponent<Movement>().jetpackOnTime > 15) {
			animator.SetInteger("FlameAnim", 1);
			jetpackFlameOffTimer = jetpackFlameOffAmount;
		}
		if (this.transform.parent.GetComponent<Movement> ().jetpackOn == false) {
			jetpackFlameOffTimer--;
		}
		if (this.transform.parent.GetComponent<Movement>().jetpackOn == false && jetpackFlameOffTimer < 1){
			animator.SetInteger("FlameAnim", 0);
		}
		if (this.transform.parent.GetComponent<Movement>().dead == true) {
			animator.SetInteger("FlameAnim", 0);
		}
	}
}
