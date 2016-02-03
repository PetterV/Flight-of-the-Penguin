using UnityEngine;
using System.Collections;

public class NewMovingBlocks : MonoBehaviour {
	public GameObject MoveToTarget;
	public GameObject MoveFromTarget;
	float movetoX = 0;
	float movetoY = 0;
	float movefromX = 0;
	float movefromY = 0;
	public int moveSpeed = 1; // the higher number the slower it moves
	public int timestoMove = 0;  
	public bool repeating = true;// if true never stops
	
	
	Vector2 movefrom;
	bool moving =false;
	Vector2 startPos;
	Vector2 endPos;
	Vector2 movePos;
	int time;
	int timed;
	bool moveStart;
	float diffX;
	float diffY;
	
	
	// Use this for initialization
	void Start () {
		movetoX = MoveToTarget.transform.position.x;
		movetoY = MoveToTarget.transform.position.y;
		movefromX = MoveFromTarget.transform.position.x;
		movefromY = MoveFromTarget.transform.position.y;
		startPos = rigidbody2D.position;
		endPos = new Vector2 (movetoX, movetoY);
		time = moveSpeed;
		movePos = new Vector2 (0, 0);
		moveStart = true;
		timed = time - 1;
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timestoMove > 0 && !moving) {
			if (!repeating)
				timestoMove -= 1;
			moving = true;				 
		}
		if (moving) {
			
			timed++;
			//Debug.Log(timed);
			if(timed > time)
			{
				if (timestoMove > 0) {
					if (!repeating)
						timestoMove -= 1;
					if(moveStart)
					{
						startPos =  new Vector2 (movefromX, movefromY);
						endPos =  new Vector2 (movetoX, movetoY);
						moveStart = false;
						//Debug.Log(startPos);
						//Debug.Log(endPos);
					}
					else{
						startPos =  new Vector2 (movetoX, movetoY);
						endPos =  new Vector2 (movefromX, movefromY);
						moveStart = true;
						//Debug.Log("endPos");
						//Debug.Log(startPos);
					}
					movePos = (endPos - startPos) / time;
					//Debug.Log(movePos);
					//Debug.Log(timed);
					timed = 0;
					
					
				}
				else{
					print (transform.position);
					moving = false;
					Debug.Log("stop");
					rigidbody2D.velocity = new Vector2(0,0);
					return;
				}
				
			}
			rigidbody2D.MovePosition(rigidbody2D.position + movePos);
		}
		
	}
	void addTimesToMove(int integer) {
		print(integer);
		timestoMove = integer;
	}
	void turnOffOn()
	{
		print ("ONOFF");
		if (repeating) {
			repeating = false;
			timestoMove = 0;
		} else {
			repeating = true;
			timestoMove = 1; 
		}
	}
}
