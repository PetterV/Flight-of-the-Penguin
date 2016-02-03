using UnityEngine;
using System.Collections;

public class TriggerAreaZoom : MonoBehaviour {
	public Camera camera;
	public float zoomTo = 0;
	public float zoomSpeed = 0.1f;
	float zoom;
	bool zoomOn = false;
	float zoomClamp;

	void Start () {

		zoomTo = Mathf.Floor(zoomTo*10)/10;
		zoom = camera.orthographicSize;
		zoomClamp = zoomSpeed + 0.1f;
	}

	void Update()
	{

		if (camera.orthographicSize < zoom && zoomOn)
			camera.orthographicSize += zoomSpeed;
		else if(camera.orthographicSize > zoom && zoomOn)
			camera.orthographicSize -= zoomSpeed;

		if (camera.orthographicSize + zoomClamp > zoom && camera.orthographicSize < zoom) {
			camera.orthographicSize = zoom;
			zoomOn = false;
		}
		if (camera.orthographicSize - zoomClamp < zoom && camera.orthographicSize > zoom) {
			camera.orthographicSize = zoom;
			zoomOn = false;
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			zoom = zoomTo;
			zoomOn = true;
		}

	}


}
