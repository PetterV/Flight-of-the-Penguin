using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour {
	public Texture2D cursorTexture;
	public Texture2D cursorTextureDown;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	bool mouseDown = false;
	void Start() {
		Cursor.SetCursor(cursorTexture, new Vector2(hotSpot.x+cursorTexture.width/2,hotSpot.y+cursorTexture.height/2), cursorMode);
	}
	void Update() {
		//optimize? check if change needed
		if (Input.GetButton ("Fire1") && !mouseDown) {
			Cursor.SetCursor (cursorTextureDown,new Vector2(hotSpot.x+cursorTextureDown.width/2,hotSpot.y+cursorTextureDown.height/2), cursorMode);
			mouseDown = true;
		} else if (!Input.GetButton ("Fire1") && mouseDown) {
			Cursor.SetCursor (cursorTexture, new Vector2(hotSpot.x+cursorTexture.width/2,hotSpot.y+cursorTexture.height/2), cursorMode);
			mouseDown = false;
		}
	}
}
