using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Sett ut et object som skal være basen og leg dette scriptet på
 * Legg ut laser ståler i verden der d vil ha dem og la dem ha en hitbox og tag dem som mines
 * dra de inn som obj1 obj2 osv.
 * 
 * Timer delay er hvor lang tid det tar før timer ON og Off starter
 * du kan deaktiere laserstålene så de starter av.
 */

public class Lazer : MonoBehaviour {
	public int timerDelay = 0;
	public int timerOn = 10;
	public int timerOff = 50;
	bool On = true;
	int currTime = 0;
	List<GameObject> objects = new List<GameObject>();
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	// Use this for initialization
	void Start () {
		if (obj1)
			objects.Add (obj1);
		if (obj2)
			objects.Add (obj2);
		if (obj3)
			objects.Add (obj3);
		if (obj4)
			objects.Add (obj4);
		
	}
	
	// Update is called once per frame
	void Update () {
		currTime++;
		if (timerDelay>0)
		{
			if(timerDelay<currTime)
				timerDelay=0;
			return;
		}
		if (timerOn < currTime && !On) {
			currTime = 0;
			On = true;
			foreach (GameObject obj in objects) {
				if (obj.activeSelf)
					obj.SetActive (false);
				else
					obj.SetActive (true);
			}
		}
		if (timerOff < currTime && On) {
			currTime = 0;
			On = false;
			foreach (GameObject obj in objects) {
				if (obj.activeSelf)
					obj.SetActive (false);
				else
					obj.SetActive (true);
			}
		}
		
	}
	

}
