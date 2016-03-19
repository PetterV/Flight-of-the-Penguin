using UnityEngine;
using System.Collections;

public class MoveFields : MonoBehaviour {

	public int accX;
	public int accY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.GetComponent<Movement>().dead != true){
			other.rigidbody2D.AddForce (new Vector2(accX, accY));
		}
	}
}
