using UnityEngine;
using System.Collections;

public class ButtonQuitToMenu : MonoBehaviour {

	public Sprite standardSprite;
	public Sprite hoverSprite; // Drag your first sprite here
	public Sprite clickSprite; // Drag your second sprite here
	bool hover;
	bool fullScreen;
	
	void OnMouseEnter() {
		
		gameObject.GetComponent<SpriteRenderer>().sprite=hoverSprite;
		
		hover = true;
	}
	
	void OnMouseExit(){
		print ("MouseExit");
		gameObject.GetComponent<SpriteRenderer>().sprite=standardSprite;
		hover = false;
	}
	
	void OnMouseDown(){
		print ("MouseDown");
		gameObject.GetComponent<SpriteRenderer>().sprite=clickSprite;
	}
	
	void OnMouseUp(){
		print ("MouseUp");
		if (hover) {
			gameObject.GetComponent<SpriteRenderer>().sprite=hoverSprite;
			Application.LoadLevel("Meny");
		}
	}
}