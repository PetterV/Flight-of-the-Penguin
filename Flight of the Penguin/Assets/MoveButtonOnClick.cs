using UnityEngine;
using System.Collections;

public class MoveButtonOnClick : MonoBehaviour {

	public float posX;
	float targetPosX;
	float moveSpeed = 10f;
	bool moveLeft = false;
	bool moveRight = false;
	public int pageNumber;
	int currentPage = 0;
	GameObject levelSelectController;

	//Holding Areas
	public GameObject holdingAreaLeft;
	public GameObject holdingAreaCenter;
	public GameObject holdingAreaRight;
	float rangeRightHAC;
	float rangeLeftHAC;

	void Start(){
		levelSelectController = GameObject.FindWithTag ("LevelSelectController");
		moveSpeed = levelSelectController.GetComponent<LoadOnClick> ().buttonTransitionSpeed;
		holdingAreaLeft = levelSelectController.GetComponent<LoadOnClick> ().holdingAreaLeft;
		holdingAreaRight = levelSelectController.GetComponent<LoadOnClick> ().holdingAreaRight;
		holdingAreaCenter = levelSelectController.GetComponent<LoadOnClick> ().holdingAreaCenter;
	}

	// Update is called once per frame
	void Update () {
		float safeRangeHAC = moveSpeed / 2;
		currentPage = levelSelectController.GetComponent<LoadOnClick> ().currentPage;
		posX = transform.position.x;
		rangeLeftHAC = holdingAreaCenter.transform.position.x - safeRangeHAC;
		rangeRightHAC = holdingAreaCenter.transform.position.x + safeRangeHAC;
		if (pageNumber < currentPage) {
			MoveToHAL();
		}
		if (pageNumber > currentPage) {
			MoveToHAR();
		}
		if (pageNumber == currentPage) {
			MoveToHAC ();
		}
	}

	void MoveToHAL(){
		if (posX > holdingAreaLeft.transform.position.x){
			float moveTo = transform.position.x - moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}
	}

	void MoveToHAR(){
		if (posX < holdingAreaRight.transform.position.x){
			float moveTo = transform.position.x + moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}
	}

	void MoveToHAC(){
		if (posX < rangeLeftHAC){
			float moveTo = transform.position.x + moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}
		if (posX > rangeRightHAC) {
			float moveTo = transform.position.x - moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}

		if (posX < rangeRightHAC && posX > rangeLeftHAC) {
			transform.position = new Vector3 (holdingAreaCenter.transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
