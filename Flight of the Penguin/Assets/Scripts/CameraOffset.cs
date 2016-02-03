using UnityEngine;
using System.Collections;

public class CameraOffset : MonoBehaviour {
	public Vector3 offset=new Vector3 (0, 0, 0);
	public float speed = 0.1f;
	GameObject mainCamera;
	 
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			mainCamera.GetComponent<SmoothCamera2D>().offset = offset;
			mainCamera.GetComponent<SmoothCamera2D>().offsetSpeed = speed;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			mainCamera.GetComponent<SmoothCamera2D>().offset  = new Vector3 (0, 0, 0);
		}
	}
}