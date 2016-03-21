using UnityEngine;
using System.Collections;

public class LoadOnHit : MonoBehaviour {


	/*
	 * Set levelLoad to the same number as the number
	 * the level you want to laod has in the 
	 * build setting index
	 * 
	 * set the level number to the number
	 * the level is in in the build list
	 * 
	 */
		
	/*
	 * Set the laodingScreen to an image that is 
	 * deactivated over the loading object 
	 * to get a nice transition
	 *
	 *
	 * Remember to have a hitbox around the object
	 * you want to have as a goal
	 */

	public int levelLoad = 0;
	public GameObject loadingScreen;
	public int levelNumber;
	public bool collectable;
	public Transform crashCounter;
	public bool completed = false;
	public int completedTimer=50;
	bool notHit=true;
	public GameObject gameMusic;

	void Start (){
		gameMusic = GameObject.FindWithTag("GameMusic");
	}

	public void Update() {
		if (completed) {
			completedTimer--;
			if(completedTimer <= 0 && Input.GetButton ("Fire1"))
			{
				LoadScene (levelLoad);
				Debug.Log("LEVEL");
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && notHit) {
			Destroy(gameMusic);
			completed = true;
			print ("Goal!");
			notHit = false;
			if(loadingScreen)
				loadingScreen.SetActive(true);


			if(!collectable)
				collectable = GameControl.control.checkCollectable(levelNumber);

			GameControl.control.LevelClear(levelNumber, collectable);
			// wait for click


		//Trigger particle fishies


		}
	
	}
		public void LoadScene(int level)
		{
			Application.LoadLevel(level);
		}
	public bool getCollected()
	{
		return collectable;
	}

	public void setCollected(bool collect)
	{
		collectable = collect;
	}
}
