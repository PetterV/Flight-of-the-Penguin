using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	// the object needs a rigidbody 2d component 
	public int rotationSpeed = 10;

	void Update () {
		rigidbody2D.MoveRotation(rigidbody2D.rotation + rotationSpeed * Time.deltaTime);
	}
}
