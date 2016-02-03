using UnityEngine;
using System.Collections;

public class DeathCounterDisplay : MonoBehaviour {

	public static int deathCounter = 0;
	public static int crashThisLevel = 0;
	public Transform target;
	public Transform theGoal;
	private bool countedDead = false;
	public static bool completedLevel2 = false;
	public static bool completedLevel3 = false;
	public static bool completedLevel4 = false;
	public static bool completedLevel5 = false;
	public static bool completedLevel6 = false;
	public static bool completedLevel7 = false;
	public static bool completedLevel8 = false;
	public static bool completedLevel9 = false;
	public static bool completedLevel10 = false;
	public static bool completedLevel11 = false;
	public static bool completedLevel12 = false;
	public bool completedLevel2Public;
	public bool completedLevel3Public;
	public bool completedLevel4Public;
	public bool completedLevel5Public;
	public bool completedLevel6Public;
	public bool completedLevel7Public;
	public bool completedLevel8Public;
	public bool completedLevel9Public;
	public bool completedLevel10Public;
	public bool completedLevel11Public;
	public bool completedLevel12Public;

//	void Awake(){
//		DontDestroyOnLoad (this.gameObject);
//	}

	void Start(){
		countedDead = false;

	}
	
	void Update(){
		completedLevel2Public = completedLevel2;
		completedLevel3Public = completedLevel3;
		completedLevel4Public = completedLevel4;
		completedLevel5Public = completedLevel5;
		completedLevel6Public = completedLevel6;
		completedLevel7Public = completedLevel7;
		completedLevel8Public = completedLevel8;
		completedLevel9Public = completedLevel9;
		completedLevel10Public = completedLevel10;
		completedLevel11Public = completedLevel11;
		completedLevel12Public = completedLevel12;

		if (target.GetComponent<Movement> ().dead == true && countedDead == false) {
			deathCounter++;
			countedDead = true;
			crashThisLevel++;
		}
		//Seeing if the player has reached the goal
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 2 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel2 = true;
			crashThisLevel = 0;
//			Debug.Log("Completed Level 2");
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 3 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel3 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 4 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel4 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 5 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel5 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 6 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel6 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 7 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel7 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 8 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel8 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 9 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel9 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 10 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel10 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 11 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel11 = true;
			crashThisLevel = 0;
		}
		if(theGoal.GetComponent<LoadOnHit>().levelNumber == 12 && theGoal.GetComponent<LoadOnHit>().completed == true){
			completedLevel12 = true;
			crashThisLevel = 0;
		}

	}

	public void ResetAll (){
		completedLevel2 = false;
		completedLevel3 = false;
		completedLevel4 = false;
		completedLevel5 = false;
		completedLevel6 = false;
		completedLevel7 = false;
		completedLevel8 = false;
		completedLevel9 = false;
		completedLevel10 = false;
		completedLevel11 = false;
		completedLevel12 = false;
		deathCounter = 0;
		crashThisLevel = 0;
	}

	void OnGUI () {
		if(Application.loadedLevelName == "Meny"){
			GUI.Box(new Rect (10,10,55,25), "Crashes".ToString() );
			GUI.Box(new Rect (70,10,40,25), "Last".ToString() );
			GUI.Box(new Rect (25,38,25,25), deathCounter.ToString() );
			GUI.Box(new Rect (80,38,25,25), crashThisLevel.ToString() );
		}
		if(Application.loadedLevelName != "Meny"){
			GUI.Box(new Rect (10,10,55,25), "Crashes".ToString() );
			GUI.Box(new Rect (70,10,50,25), "Current".ToString() );
			GUI.Box(new Rect (25,38,25,25), deathCounter.ToString() );
			GUI.Box(new Rect (80,38,25,25), crashThisLevel.ToString() );
		}		
	}

	public void ResetCounter () {
		crashThisLevel = 0;
	}
	
}
