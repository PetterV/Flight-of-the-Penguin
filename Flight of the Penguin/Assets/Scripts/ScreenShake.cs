using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {
		
	Vector3 originalCameraPosition;
		
//	float shakeAmt = 0;
	float cooldown = 0;

	public Camera mainCamera;
	void Update(){
		
		if (cooldown > 0)
			cooldown--;
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if ((coll.relativeVelocity.x > 30 || coll.relativeVelocity.x < -30) || (coll.relativeVelocity.y > 30 || coll.relativeVelocity.y < -30)  && cooldown < 10) {
			StartCoroutine (Shake ());
			cooldown = 120;
			print(cooldown);
		}

		Debug.Log ("happend");
		print(cooldown);
	}
		
	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		float duration = 0.2f;
		float magnitude = 0.2f;
		Debug.Log ("SHAKE");
		
		Vector3 originalCamPos = Camera.main.transform.position;
		
		while (elapsed < duration) {
			
			elapsed += 0.01f;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x =(x *= magnitude * damper) / 7;
			y =(y *= magnitude * damper) / 7;
			
			Camera.main.transform.position = new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, originalCamPos.z);
			
			yield return null;
		}
		
		Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, originalCamPos.z);
	}
		
}