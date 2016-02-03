using UnityEngine;
using System.Collections;

/* Set a  collider2D with trigger active
 * Cannon strenght is how fast pingu will leave the cannon
 */


public class Cannon : MonoBehaviour {
	public float CannonStrength = 10000.0f;
	int playerCollisionTimer = 10;
	int noShootTime= 10;
	bool pinguCollision =false;
	Vector3 mousePosition;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 force=new Vector3( mousePosition.x-transform.position.x, mousePosition.y-transform.position.y,0).normalized;
		//print (force.y);
		if (force.y > 0.3f && pinguCollision) {
			Quaternion rot = Quaternion.LookRotation (transform.position - new Vector3 (mousePosition.x, mousePosition.y, -100), Vector3.forward);
			transform.rotation = rot;
		
			//Strip away x and y rotation of the character
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		}
		if(playerCollisionTimer>0)
			playerCollisionTimer--;

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.rigidbody2D.velocity = new Vector2 (0, 0);
			noShootTime=10;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			pinguCollision = true;
			if(playerCollisionTimer<2)
			{
				other.transform.position = transform.position;
				other.gameObject.SendMessage ("CannonOn");
			

			if(noShootTime > 0)
				noShootTime--;
			if(Input.GetButton ("Fire1") && noShootTime < 1)
			{
				print ("FIRE");
				playerCollisionTimer=50;
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 force=new Vector3( mousePosition.x-transform.position.x, mousePosition.y-transform.position.y,0).normalized;
				Vector3 temp = new Vector3(transform.position.x,transform.position.y+0.1f,transform.position.z);
				if(force.y>0.3f){
				other.transform.position = temp;
				other.rigidbody2D.velocity=new Vector2(force.x*CannonStrength,force.y*CannonStrength);
				}
				print (force);
			}
			else
				other.rigidbody2D.velocity=new Vector2(0,0);
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			pinguCollision = false;
			other.gameObject.SendMessage ("CannonOff");
		}
	}
}
