using UnityEngine;
using System.Collections;

public class ShowAcceptedStamp : MonoBehaviour {

	public Transform checkForComplete;
	public GameObject stamp;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		//Level 1
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel2Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 2){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel2Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 2){
			stamp.SetActive(false);
		}
		//Level 2
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel3Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 3){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel3Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 3){
			stamp.SetActive(false);
		}

		//Level 3
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel4Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 4){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel4Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 4){
			stamp.SetActive(false);
		}
		
		//Level 4
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel5Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 5){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel5Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 5){
			stamp.SetActive(false);
		}
		
		//Level 5
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel6Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 6){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel6Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 6){
			stamp.SetActive(false);
		}
		
		//Level 6
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel7Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 7){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel7Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 7){
			stamp.SetActive(false);
		}

		//Level 7
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel8Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 8){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel8Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 8){
			stamp.SetActive(false);
		}
		
		//Level 8
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel9Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 9){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel9Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 9){
			stamp.SetActive(false);
		}
		
		//Level 9
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel10Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 10){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel10Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 10){
			stamp.SetActive(false);
		}
		
		//Level 10
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel11Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 11){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel11Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 11){
			stamp.SetActive(false);
		}
		
		
		//Level 11
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel12Public == true && this.GetComponent<ButtonLoadLevel>().loadLevel == 12){
			stamp.SetActive(true);
		}
		if(checkForComplete.GetComponent<DeathCounterDisplay>().completedLevel12Public == false && this.GetComponent<ButtonLoadLevel>().loadLevel == 12){
			stamp.SetActive(false);
		}
	}
}
