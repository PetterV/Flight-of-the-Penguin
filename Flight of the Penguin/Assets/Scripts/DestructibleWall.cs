using UnityEngine;
using System.Collections;

public class DestructibleWall : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Mine" ){
			Destroy (gameObject);
			Destroy (coll.gameObject);
		}
	}
}
