using UnityEngine;
using System.Collections;

public class AnimateBouncer : MonoBehaviour {
	private Animator animator;
	public int bounceTimeSet = 100;
	private int bounceTime = 0;
	private int bounceTracker = 0;
	public Material bounceWide;
	public Material bounceThin;

	void Start (){
		animator = GetComponent<Animator> ();
		bounceTime = bounceTimeSet;
	}

	void OnCollisionEnter2D(Collision2D coll){
		animator.SetInteger ("Bounce", 1);
		bounceTracker = 1;
		bounceTime = bounceTimeSet;
	}
	// Update is called once per frame
	void Update () {
		if (bounceTracker == 1){
			bounceTime--;
		}
		if (bounceTime == 0){
			animator.SetInteger ("Bounce", 1);
			bounceTracker = 0;
		}
		if (bounceTracker == 0){
			animator.SetInteger ("Bounce", 0);
		}
	}
}
