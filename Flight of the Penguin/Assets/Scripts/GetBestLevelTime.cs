using UnityEngine;
using System.Collections;

public class GetBestLevelTime : MonoBehaviour {
	public int levelNum=1;
	public float levelTimer=0;
	public bool levelCleared=false;
	public Timer timer;
	public GameObject levelStamp;
	public float parTime;
	public GameObject parMedal;

	// Use this for initialization
	void Start () {
		levelTimer=GameControl.control.CheckLevelTime(levelNum);
		levelCleared=GameControl.control.CheckLevelClear(levelNum);
		int sek1 = (int)Mathf.Floor (levelTimer);
		int sek2 = (int)Mathf.Floor (sek1 / 10);
		int min1 = sek1 / 60;
		int min2 = min1 % 10;
		min1 = (int)Mathf.Floor (min1);
		min1 = min1 % 10;
		sek1 = sek1 % 10;
		int hund1 = (int)Mathf.Floor (levelTimer*100);
		int hund2 = (int)Mathf.Floor ((hund1 % 100)/10);
		hund1 = hund1 % 10;

		timer.setTimer (min2, min1, sek2, sek1, hund2, hund1);

		//Fix stamps and medals here
		if (!levelCleared) {
			levelStamp.SetActive (false);
		}
		if (levelTimer == 0 || levelTimer > parTime) {
			parMedal.SetActive(false);
		}
	}
}
