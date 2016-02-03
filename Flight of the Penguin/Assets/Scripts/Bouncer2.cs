using UnityEngine;
using System.Collections;

public class Bouncer2 : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		

		
		if(coll.gameObject.tag=="Player")//add in mines when time
		{ 

			Vector3 direction = coll.gameObject.GetComponent<Movement>().getDir();
			print (direction);
			float speed = Mathf.Abs(coll.relativeVelocity.x) + Mathf.Abs(coll.relativeVelocity.y);
			speed = Mathf.Floor(speed*100)/100;
			print(speed);
			print(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed));
			if(speed>20)
				speed = 20;
			coll.gameObject.rigidbody2D.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed/1) , ForceMode2D.Impulse);
		}

		if(coll.gameObject.tag=="Mine")//add in mines when time
		{ 
			
			Vector3 direction = coll.gameObject.rigidbody2D.velocity.normalized;
			print (direction);
			float speed = Mathf.Abs(coll.relativeVelocity.x) + Mathf.Abs(coll.relativeVelocity.y);
			speed = Mathf.Floor(speed*100)/100;
			print(speed);
			print(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed));
			if(speed>20)
				speed = 20;
			coll.gameObject.rigidbody2D.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * (speed) , ForceMode2D.Impulse);
		}
	}
}