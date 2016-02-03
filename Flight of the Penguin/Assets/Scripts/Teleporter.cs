using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public GameObject otherTeleporter;
	public Teleporter tele;
	public bool OnOff;
	// Use this for initialization
	void Start () {
		OnOff = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (OnOff) {
			other.transform.position = otherTeleporter.transform.position;
			tele = otherTeleporter.GetComponent<Teleporter> ();
			tele.OnOff = false;
		}

		} 
	void OnTriggerExit2D()
	{
		//might need a timer
		OnOff = true;
	}
}
