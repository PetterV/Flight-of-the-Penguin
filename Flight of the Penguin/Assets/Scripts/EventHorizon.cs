using UnityEngine;
using System.Collections;

public class EventHorizon : MonoBehaviour {

	public float pull=10;
	public float push=10;
	float radius;
	// Use this for initialization
	void Start () {
		if (gameObject.collider2D is CircleCollider2D) {
			radius = ((CircleCollider2D)gameObject.collider2D).bounds.extents.y;

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D other){
		other.rigidbody2D.drag = 2;
		other.rigidbody2D.AddForce ((((other.transform.position - transform.position) * -1).normalized) * pull * (radius- Mathf.Abs(Vector3.Distance(transform.position,other.transform.position))));

		print ( (radius- Mathf.Abs(Vector3.Distance(transform.position,other.transform.position))));

		//Vector3 grav = ((((other.transform.position - transform.position)*-1).normalized)*pull);
		//other.rigidbody2D.AddForce(grav+(other.transform.position - transform.position)*push);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		other.rigidbody2D.drag = 0.1f;
	}

}
