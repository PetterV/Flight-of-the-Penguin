using UnityEngine;
using System.Collections;

public class LaunchShake : MonoBehaviour {

	public float launchDuration = 0.5f;
	public float launchSpeed = 1.0f;
	public float launchMagnitude = 0.1f;
	
	public bool launch = false;
//	public bool launchOnce = true;
	public bool paused = false;
	
	// -------------------------------------------------------------------------
	public void PlayShake() {
		
		StopAllCoroutines();
		StartCoroutine("Shake");
	}
	
	// -------------------------------------------------------------------------
	void FixedUpdate() {
		if (!paused) {
			if (launch == true) {
				launch = false;
//			launchOnce = false;
				PlayShake ();
			}
		}
	}
	
	// -------------------------------------------------------------------------
	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		Vector3 originalCamPos = Camera.main.transform.position;
		
		float randomStart = Random.Range(-50.0f, 50.0f);
		
		while (elapsed < launchDuration && !paused) {
			
			elapsed += Time.deltaTime;			
			
			float percentComplete = elapsed / launchDuration;			
			
			// We want to reduce the shake from full power to 0 starting half way through
			float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);
			
			// Calculate the noise parameter starting randomly and going as fast as speed allows
			float alpha = randomStart + launchSpeed * percentComplete;
			
			// map noise to [-1, 1]
			float x = Util.Noise.GetNoise(alpha, 0.0f, 0.0f) * 2.0f - 1.0f;
			float y = Util.Noise.GetNoise(0.0f, alpha, 0.0f) * 2.0f - 1.0f;
			
			x *= launchMagnitude * damper;
			y *= launchMagnitude * damper;
			
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
