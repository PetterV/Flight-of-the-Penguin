using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour {
	public Texture2D cursorTexture;
	public Texture2D cursorTextureDown;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	bool mouseDown = false;
	void Awake() {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	void Update() {
		//optimize? check if change needed
		if (Input.GetButton ("Fire1") && !mouseDown) {
			Cursor.SetCursor (cursorTextureDown, hotSpot, cursorMode);
			mouseDown = true;
		} else if (!Input.GetButton ("Fire1") && mouseDown) {
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
			mouseDown = false;
		}
	}
}
