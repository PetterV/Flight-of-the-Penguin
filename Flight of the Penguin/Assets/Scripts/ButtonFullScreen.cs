using UnityEngine;
using System.Collections;

public class ButtonFullScreen : MonoBehaviour {
	
	public Sprite standardSprite;
	public Sprite hoverSprite; // Drag your first sprite here
	public Sprite clickSprite; // Drag your second sprite here
	bool hover;
	bool fullScreen;
	// Use this for initialization
	
	
	
	void Start() {
	}
	
	
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
			if (PlayerPrefs.GetInt("FullScreen") < 1) {
				PlayerPrefs.SetInt("FullScreen",1);
				Screen.fullScreen = !Screen.fullScreen;
			}
			else {

				PlayerPrefs.SetInt("FullScreen",0);
				Screen.fullScreen = !Screen.fullScreen;
			}
		}
	}
}