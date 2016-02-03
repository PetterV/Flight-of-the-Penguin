using UnityEngine;
using System.Collections;

public class ButtonMute : MonoBehaviour {

	public Sprite standardSprite;
	public Sprite hoverSprite; // Drag your first sprite here
	public Sprite clickSprite; // Drag your second sprite here
	AudioSource audio;
	bool hover;
	// Use this for initialization
	

	
	void Start() {
		audio = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource>();
		
		hover = true;
	}

	void OnMouseEnter(){
		print ("MouseHover");
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
			gameObject.GetComponent<SpriteRenderer>().sprite=standardSprite;
			if (!GameControl.control.mute) {
				Mute ();
				GameControl.control.mute = true;
				PlayerPrefs.SetInt("Mute",1);
			}
			else if (GameControl.control.mute) {
				GameControl.control.mute = false;
				Mute();
				PlayerPrefs.SetInt("Mute",0);
			}

		}
	}
	public void Mute() {
		if (audio.mute)
			audio.mute = false;
		else
			audio.mute = true;
		print (audio.mute);
		
	}
}