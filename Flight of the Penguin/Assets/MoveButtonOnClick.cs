using UnityEngine;
using System.Collections;

public class MoveButtonOnClick : MonoBehaviour {

	public float posX;
	float frameLength = 100;
	float targetPosX;
	float moveSpeed = 10f;
	bool move = false;
	public int pageNumber;
	int currentPage;
	int pageToBringIn;

	// Update is called once per frame
	void Update () {
		posX = transform.position.x;
		if (move == true) {
			MoveButton();
		}
	}

	void MoveButton(){
		if (posX > targetPosX){
			float moveTo = transform.position.x - moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}
		if (posX <= targetPosX) {
			move = false;
		}
	}

	public void ActivateLeft (){
		targetPosX = posX - frameLength;
		currentPage = currentPage + 1;
		move = true;
	}

	public void ActivateRight(){
		targetPosX = posX + frameLength;
		currentPage = currentPage - 1;
		move = true;
	}
}
