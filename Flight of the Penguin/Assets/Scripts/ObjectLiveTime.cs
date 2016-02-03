using UnityEngine;
using System.Collections;

public class ObjectLiveTime : MonoBehaviour {

	public int timer = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
		if (timer < 1) {
			Destroy (gameObject);

		}
	}

	public void setTimer(int time)
	{
		timer = time;
	}
}
