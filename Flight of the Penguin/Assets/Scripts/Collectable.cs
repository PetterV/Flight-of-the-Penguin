using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public GameObject goal;
	bool collected = false;

	// Use this for initialization
	void Start () {
	
		collected = goal.GetComponent<LoadOnHit>().getCollected();
		//if (collected)
		//	Destroy (gameObject); //remove for build
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			collected = true;
			goal.GetComponent<LoadOnHit> ().collectable = true;
			//play spound?
			Destroy(gameObject);
		}
	}
}
