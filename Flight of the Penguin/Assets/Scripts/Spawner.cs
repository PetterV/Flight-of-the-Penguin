using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject obj;
	public float randX = 0;
	public float randY = 0;
	public float y = 5.0f;
	public float x = 0.0f;
	public int timer = 250;
	public int spawnedObjTimer = 40;
	public bool boolSpawnedObjTimer = false; // if this is false the objects spawned will never die
	public int numberOfSpawns= 5;
	int currTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (obj) {
			if (timer < currTime  && numberOfSpawns > 0) {
				currTime = 0;
				numberOfSpawns --;

				GameObject newObject = (GameObject)Instantiate (obj, new Vector3 (transform.position.x +Random.Range(-randX,randX)+ x, transform.position.y + Random.Range(-randY,randY) + y, transform.position.z), Quaternion.identity);

				if(boolSpawnedObjTimer)
				{
					newObject.AddComponent<ObjectLiveTime>();
					newObject.GetComponent<ObjectLiveTime>().setTimer(spawnedObjTimer);
				}
							}
			currTime++;
		}

	}
}
