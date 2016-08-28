using UnityEngine;
using System.Collections;

public class GetTimerHere : MonoBehaviour {

	public GameObject realTimer;
	public GameObject newTimerBox;
	bool hasntCopiedYet = true;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (hasntCopiedYet) {
			realTimer.transform.position = this.gameObject.transform.position;
			realTimer.transform.localScale = newTimerBox.gameObject.transform.localScale;
			hasntCopiedYet = false;
		}
	}
}
