using UnityEngine;
using System.Collections;

public class FlyShake : MonoBehaviour {

	public float flyDuration = 0.5f;
	public float flySpeed = 1.0f;
	public float flyMagnitude = 0.1f;
	
	public bool fly = false;
	//	public bool flyOnce = true;
	
	// -------------------------------------------------------------------------
	public void PlayShake() {
		
		StopAllCoroutines();
		StartCoroutine("Shake");
	}
	
	// -------------------------------------------------------------------------
	void Update() {
		
		if (fly == true) {
			//			flyOnce = false;
			PlayShake();
		}
	}
	
	// -------------------------------------------------------------------------
	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		Vector3 originalCamPos = Camera.main.transform.position;
		
		float randomStart = Random.Range(-50.0f, 50.0f);
		
		while (elapsed < flyDuration) {
			
			elapsed += Time.deltaTime;			
			
			float percentComplete = elapsed / flyDuration;			
			
			// We want to reduce the shake from full power to 0 starting half way through
			float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);
			
			// Calculate the noise parameter starting randomly and going as fast as speed allows
			float alpha = randomStart + flySpeed * percentComplete;
			
			// map noise to [-1, 1]
			float x = Util.Noise.GetNoise(alpha, 0.0f, 0.0f) * 2.0f - 1.0f;
			float y = Util.Noise.GetNoise(0.0f, alpha, 0.0f) * 2.0f - 1.0f;
			
			x *= flyMagnitude * damper;
			y *= flyMagnitude * damper;
			
			float xPos = (float)transform.position.x;
			float yPos = (float)transform.position.y;
			
			float xReal = xPos + x * 0.1f;
			float yReal = yPos + y * 0.1f;
			
			Camera.main.transform.position = new Vector3(xReal, yReal, originalCamPos.z);
			
			yield return null;
		}
		
		//		Camera.main.transform.position = originalCamPos;
	}
}
