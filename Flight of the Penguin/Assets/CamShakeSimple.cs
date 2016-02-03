using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour 
{
	public float shakeAmtCrash = 0;
	public float shakeAmtFly = 0;
	public float flyVariable = 1f;
	
	public Camera mainCamera;
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (this.transform.GetComponent<Movement>().dead == true){
			shakeAmtCrash = 3;
		}
		if (this.transform.GetComponent<Movement>().speedCounter > 0.1) {
		shakeAmtCrash = coll.relativeVelocity.magnitude * 0.5f * .0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
		}
	}
	
	void CameraShake()
	{
		if(shakeAmtCrash>0)
		{
			float quakeAmtCrash = Random.value*shakeAmtCrash*2 - shakeAmtCrash;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmtCrash; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}

	void Update () {

		if (this.transform.GetComponent<Movement>().jetpackOn == true && this.transform.GetComponent<Movement>().jetpackOnTime < 10){
			shakeAmtFly = flyVariable * .005f;
			InvokeRepeating("CameraShakeFly", 0, .01f);
			Invoke("StopShakingFly", 0.3f);
		}

		if (this.transform.GetComponent<Movement>().jetpackOn == true){
			shakeAmtFly = flyVariable * 0.5f * .0025f;
			InvokeRepeating("CameraShakeFly", 0, .01f);
		}

		if (this.transform.GetComponent<Movement>().jetpackOn == false){
			Invoke("StopShakingFly", 0.3f);
		}

	}

	void CameraShakeFly()
	{
		if(shakeAmtFly>0)
		{
			float quakeAmtFly = Random.value*shakeAmtFly*2 - shakeAmtFly;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmtFly; // can also add to x and/or z
			pp.x+= quakeAmtFly;
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
	}

	void StopShakingFly()
	{
		CancelInvoke("CameraShakeFly");
	}
	
}