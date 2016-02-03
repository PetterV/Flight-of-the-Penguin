using UnityEngine;
using System.Collections;

public class Bobbing : MonoBehaviour {

	public float bobbRangeY = 1;
	public float bobbRangeX = 1;
	public float bobbSpeed = 0.01f;
	public bool bobbY;
	public bool bobbX;
	float bobbCurrentY;
	float bobbCurrentX;
	float startY;
	bool up;
	float posY;
	float startX;
	bool vert;
	float posX;

	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		bobbCurrentY = startY + Random.Range (1, bobbRangeY);
		up = true;
	}
	
	// Update is called once per frame
	void Update () {
		posY = transform.position.y;
		if (bobbY == true){
			if (up && bobbCurrentY > transform.position.y) {
				Vector3 temp = transform.position; 
				temp.y = posY + bobbSpeed;
				transform.position = temp;
			} else if (up && bobbCurrentY < transform.position.y) {
				bobbCurrentY = startY + Random.Range (-bobbRangeY, -0);
				up = false;
			} else if (!up && bobbCurrentY < transform.position.y) {
				Vector3 temp = transform.position; 
				temp.y = posY - bobbSpeed;
				transform.position = temp;
				;
			} else if (!up && bobbCurrentY > transform.position.y) {
				bobbCurrentY = startY + Random.Range (0, bobbRangeY);
				up = true;
			}
		}

		posX = transform.position.x;
		if (bobbX == true) {
			if (vert && bobbCurrentX > transform.position.x) {
				Vector3 temp = transform.position; 
				temp.x = posX + bobbSpeed;
				transform.position = temp;
			} else if (vert && bobbCurrentX < transform.position.x) {
				bobbCurrentX = startX + Random.Range (-bobbRangeX, -0);
				vert = false;
			} else if (!vert && bobbCurrentX < transform.position.x) {
				Vector3 temp = transform.position; 
				temp.x = posX - bobbSpeed;
				transform.position = temp;
				;
			} else if (!vert && bobbCurrentX > transform.position.x) {
				bobbCurrentX = startX + Random.Range (0, bobbRangeX);
				vert = true;
			}
		}
	}
}
