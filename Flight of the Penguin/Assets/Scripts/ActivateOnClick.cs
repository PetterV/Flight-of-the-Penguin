using UnityEngine;
using System.Collections;

public class ActivateOnClick : MonoBehaviour {

	public GameObject objectToActivate;
	public GameObject objectToDeActivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickActivate()
	{
		objectToActivate.SetActive(true);
	}

	public void OnClickDeActivate()

	{
		objectToDeActivate.SetActive(false);
	}

}
