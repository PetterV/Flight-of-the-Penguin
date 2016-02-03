using UnityEngine;
using System.Collections;

public class MovBloFollowingPlayer : MonoBehaviour {
	/*
	 * Have an object with a collider 2D and a RigidBody 2D
	 * drag an object onto the Player field, this objects needs the Movement script.
	 * Have a tag set as ZoneHide if you want the player to be able to hide
	 * set an object with a collider 2D on this objet to a trigger and set the tag
	 */
	
	public int moveSpeed = 1; // the lower number the slower it moves
	public int waitTime = 2;
	int currTime=0;
	public float detectrRange = 100;// range it detects the player and starts to chase
	public GameObject Player; //the target it chases

	Movement playerMove;

	bool move;
	
	// Use this for initialization
	void Start () {
		move = false;
	
		playerMove = Player.GetComponent<Movement>();
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		if (waitTime < currTime) {
			if (playerMove.detectable) {
				if ((Mathf.Abs (Player.rigidbody2D.position.x - rigidbody2D.position.x) < detectrRange) && (Mathf.Abs (Player.rigidbody2D.position.y - rigidbody2D.position.y) < detectrRange)) {
					move = true;
				} else 
					move = false;
			} else 
				move = false;

			if (move)
				rigidbody2D.AddForce (((Player.transform.position - transform.position).normalized) * moveSpeed);
		} else
			currTime++;

	}

}
	

