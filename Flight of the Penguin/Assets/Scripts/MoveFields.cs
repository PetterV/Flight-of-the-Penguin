using UnityEngine;
using System.Collections;

public class MoveFields : MonoBehaviour {

	public int accX;
	public int accY;
	public bool affectMine = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			print("something");
			if (other.GetComponent<Movement>().dead != true){
				other.rigidbody2D.AddForce (new Vector2(accX, accY));
			}
		}
		
		if (other.gameObject.tag == "PhysicsObject"){
			other.rigidbody2D.AddForce (new Vector2(accX, accY));
		}
		
		if (affectMine == true){
			if (other.tag == "Mine"){
				print("pushing mine");
				other.rigidbody2D.AddForce (new Vector2(accX, accY));
			}
		}
	}
}
