using UnityEngine;
using System.Collections;

public class MouseCursorChange : MonoBehaviour {

	public Texture2D cursorTexture;
	public Texture2D cursorTextureSmall;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	void Start() {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	void update(){
		if(Input.GetMouseButton (0)){
			cursorTexture = cursorTextureSmall;
		}
//		if(Input.GetButtonUp ("Fire1")){
//			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
//		}
	}

	void OnMouseExit() {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
}
