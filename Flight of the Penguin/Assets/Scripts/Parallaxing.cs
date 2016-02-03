using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public float scrollSpeed;
	float originX;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		originX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =  new Vector3 (originX + (scrollSpeed*player.transform.position.x)/100, transform.position.y, transform.position.z);
	}
}
