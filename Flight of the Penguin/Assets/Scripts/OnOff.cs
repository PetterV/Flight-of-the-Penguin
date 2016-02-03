using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OnOff : MonoBehaviour {
	List<GameObject> objects = new List<GameObject>();
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public bool playerOnly = true;
	// Use this for initialization
	void Start () {
		if (obj1)
			objects.Add (obj1);
		if (obj2)
			objects.Add (obj2);
		if (obj3)
			objects.Add (obj3);
		if (obj4)
			objects.Add (obj4);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (playerOnly){
			if(coll.gameObject.tag == "Player") {
				foreach (GameObject obj in objects) {
					if (obj) {
						if (obj.activeSelf)
							obj.SetActive (false);
						else
							obj.SetActive (true);
					}
				}
			}
		} else if (coll.gameObject.tag == "Mine" || coll.gameObject.tag == "Player"){
			foreach (GameObject obj in objects) {
				if (obj) {
					if (obj.activeSelf)
						obj.SetActive (false);
					else
						obj.SetActive (true);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (playerOnly) {
			if (coll.gameObject.tag == "Player") {
			
				foreach (GameObject obj in objects) {
					if (obj) {
						if (obj.activeSelf)
							obj.SetActive (false);
						else
							obj.SetActive (true);
					}
				}
			} 
		}else if (coll.gameObject.tag == "Mine" || coll.gameObject.tag == "Player"){
			foreach (GameObject obj in objects) {
				if (obj) {
					if (obj.activeSelf)
						obj.SetActive (false);
					else
						obj.SetActive (true);
				}
			}
		}
	}
}
