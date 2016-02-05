using UnityEngine;
using System.Collections;

public class MoveButtonOnClick : MonoBehaviour {

	public float posX;
	public float frameLength = 100;
	public float targetPosX;
	public float moveSpeed = 10f;
	bool moveLeft = false;

	void Start (){
		posX = transform.position.x;
		targetPosX = posX - frameLength;
	}

	// Update is called once per frame
	void Update () {
		posX = transform.position.x;
		if (moveLeft == true) {
			MoveButtonLeft();
		}
	}

	void MoveButtonLeft(){
		if (posX > targetPosX){
			float moveTo = transform.position.x - moveSpeed;
			transform.position = new Vector3 (moveTo, transform.position.y, transform.position.z);
		}
		if (posX <= targetPosX) {
			moveLeft = false;
		}
	}

	public void Activate (){
		moveLeft = true;
	}
}
