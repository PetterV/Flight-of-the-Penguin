using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public Vector3 offset =  new Vector3(0,0,0);
	public float offsetSpeed = 0.1f;
	Vector3 currOffset =  new Vector3(0,0,0);
	
	// Update is called once per frame
	void Update () 
	{
		if (target.GetComponent<Movement> ().dead == false) {

			if ((currOffset.x + offsetSpeed + 0.1f > offset.x && currOffset.x < offset.x) || (currOffset.x - 0.2f < offset.x && currOffset.x > offset.x))
				currOffset.x = offset.x;
			else if (currOffset.x < offset.x)
				currOffset.x += offsetSpeed;
			else if (currOffset.x > offset.x)
				currOffset.x -= offsetSpeed;

			if ((currOffset.y + offsetSpeed + 0.1f > offset.y && currOffset.y < offset.y) || (currOffset.y - 0.2f < offset.y && currOffset.y > offset.y))
				currOffset.y = offset.y;
			else if (currOffset.y < offset.y)
				currOffset.y += offsetSpeed;
			else if (currOffset.y > offset.y)
				currOffset.y -= offsetSpeed;
			if (target) {
				Vector3 point = camera.WorldToViewportPoint (target.position);
				Vector3 delta = target.position - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
				Vector3 destination = transform.position + delta + currOffset;
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			}
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0 && camera.orthographicSize > 2)
		{
			camera.orthographicSize-=0.5f;
			print(camera.orthographicSize);
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") < 0 & camera.orthographicSize < 8)
		{
			camera.orthographicSize+=0.5f;
			print(camera.orthographicSize);
		}

		
	}
}