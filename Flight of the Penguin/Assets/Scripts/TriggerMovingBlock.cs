using System.Collections;
using UnityEngine;

public class TriggerMovingBlock : MonoBehaviour {
	/*
	 * select the moving block/mine you want to move
	 * and type in the number of times you want it to move +1
	 */
	
	public GameObject movingBlock;
	public int numberToMove;
	public bool repeating = false;
	public bool repeatable = true;
	bool interactable = true;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll) {
		if (interactable && coll.gameObject.tag == "Player"){
			if (repeating == false) 
					movingBlock.SendMessage ("addTimesToMove", numberToMove);
			else
					movingBlock.SendMessage ("turnOffOn");

			if (repeatable == false) 
				interactable = false;

		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (interactable && coll.gameObject.tag == "Player"){
			if (repeating == false) 
					movingBlock.SendMessage ("addTimesToMove", numberToMove);
			else
					movingBlock.SendMessage ("turnOffOn");
			if (repeatable == false) 
				interactable = false;
		}
	}
}