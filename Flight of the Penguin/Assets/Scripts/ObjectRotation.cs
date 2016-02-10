using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	// the object needs a rigidbody 2d component 
	public float rotationSpeed = 10f;

	void Update () {
		transform.Rotate(new Vector3(0,0,0 - rotationSpeed * Time.deltaTime));
	}
}
