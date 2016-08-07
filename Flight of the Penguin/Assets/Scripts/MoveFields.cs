using UnityEngine;
using System.Collections;

public class MoveFields : MonoBehaviour {

	public int accX;
	public int accY;
	public bool affectMine = false;
	GameObject player;
	Component movement;
	// Use this for initialization
	void Start(){
		player = GameObject.FindWithTag ("Player");
	}


	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			if (other.GetComponent<Movement>().dead != true){
				other.rigidbody2D.AddForce (new Vector2(accX, accY));
				other.GetComponent<Movement>().Gravity = other.GetComponent<Movement>().GravityStart;
			}
		}
		
		if (other.gameObject.tag == "PhysicsObject"){
			other.rigidbody2D.AddForce (new Vector2(accX, accY));
		}
		
		if (affectMine == true){
			if (other.tag == "Mine" || other.tag == "Ball"){
				other.rigidbody2D.AddForce (new Vector2(accX, accY));
			}

		}


	}
}
