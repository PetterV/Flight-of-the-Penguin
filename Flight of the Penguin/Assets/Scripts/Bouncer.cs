using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {
	bool onePunch = true;
	
	void Update(){
		onePunch = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {

		
		if(coll.gameObject.tag=="Player" && onePunch)//add in mines when time
		{ 
			onePunch = false;
			Vector3 direction = coll.gameObject.GetComponent<Movement>().getDir();
			print (direction);
			float speed = Mathf.Abs(coll.relativeVelocity.x) + Mathf.Abs(coll.relativeVelocity.y);
			speed = Mathf.Floor(speed*100)/100;
			print(speed);
			print(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed));
			if(speed>100)
				speed = 100;
			coll.gameObject.rigidbody2D.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed*0.9f) , ForceMode2D.Impulse);
			coll.gameObject.GetComponent<Movement>().Gravity = coll.gameObject.GetComponent<Movement>().GravityStart;
		}

		if(coll.gameObject.tag=="Mine")//add in mines when time
		{ 
			
			Vector3 direction = coll.gameObject.rigidbody2D.velocity.normalized;
			print (direction);
			float speed = Mathf.Abs(coll.relativeVelocity.x) + Mathf.Abs(coll.relativeVelocity.y);
			speed = Mathf.Floor(speed*100)/100;
			print(speed);
			print(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed));
			if(speed>10)
				speed = 10;
			coll.gameObject.rigidbody2D.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed) , ForceMode2D.Impulse);
		}
	}
}