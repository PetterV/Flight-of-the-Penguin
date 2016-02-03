using UnityEngine;
using System.Collections;

public class SptieChanger : MonoBehaviour {

	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	
	private SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}
	
	void Update ()
	{

	}
	
	public void ChangeTheDamnSprite ()
	{
		if (spriteRenderer.sprite == sprite1) 
		{
			spriteRenderer.sprite = sprite2;
		}
		else
		{
			spriteRenderer.sprite = sprite1;
		}
	}
	public void ChangeTheDamnSprite (Sprite spriteName)
	{
		if (spriteName) 
		{
			spriteRenderer.sprite = spriteName;
		}

	}
}