using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {
	bool startTimer = false;
	public Sprite zero;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	public GameObject hund1Window;
	public GameObject hund2Window;
	public GameObject sek2Window;
	public GameObject min1Window;
	public GameObject min2Window;
	private SpriteRenderer rendererhund1;
	private SpriteRenderer rendererhund2;
	private SpriteRenderer renderer;
	private SpriteRenderer renderer2;
	private SpriteRenderer renderer3;
	private SpriteRenderer renderer4;
	private List<Sprite> sprites = new List<Sprite>();
	float hund1 = 0;
	int hund2 = 0;
	float sek1=0;
	int sek2 = 0;
	int min1 = 0;
	int min2 = 0;
	float timer= 0;
	// Use this for initialization
	void Start () {
		rendererhund1 = hund1Window.GetComponent<SpriteRenderer> ();
		rendererhund2 = hund2Window.GetComponent<SpriteRenderer>();
		renderer = gameObject.GetComponent<SpriteRenderer>();
		renderer2 = sek2Window.GetComponent<SpriteRenderer> ();
		renderer3 = min1Window.GetComponent<SpriteRenderer>();
		renderer4 = min2Window.GetComponent<SpriteRenderer>();

		sprites.Add (zero);
		sprites.Add (one);
		sprites.Add (two);
		sprites.Add (three);
		sprites.Add (four);
		sprites.Add (five);
		sprites.Add (six);
		sprites.Add (seven);
		sprites.Add (eight);
		sprites.Add (nine);

		//Test
		rendererhund1.sprite = zero;
		rendererhund2.sprite = zero;
		renderer.sprite = zero;
		renderer2.sprite = zero;
		renderer3.sprite = zero;
		renderer4.sprite = zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")){
			startTimer = true;
		}

		if (startTimer) {
			sek1 += Time.deltaTime;
			hund1 += Time.deltaTime;
			float seconds = sek1 % 60;
//		print ("Start this ConnectionTesterStatus");
//		print(renderer.sprite.name);
//		print (zero.name);
			int sek1floor = (int)Mathf.Floor (seconds);
			int hundFloor = (int)Mathf.Floor (hund1 * 100);
			print (hundFloor);
			if (hundFloor >= 10) {
				print (hund1);
				hund1 = 0;
				hundFloor = 0;
				hund2++;
				if (hund2 == 10)
					hund2 = 0;

				rendererhund2.sprite = (Sprite)sprites [hund2];
			}
			rendererhund1.sprite = (Sprite)sprites [hundFloor];
			if (sek1floor == 10) {
				sek1 = 0;
				sek2 += 1;
				sek1floor = 0;
				if (sek2 == 6) {
					sek2 = 0;
					min1++;
					if (min1 == 10) {
						min1 = 0;
						min2++;
						if (min2 == 10)
							Application.LoadLevel (Application.loadedLevelName);
						renderer4.sprite = (Sprite)sprites [min2];
					}
					renderer3.sprite = (Sprite)sprites [min1];
				}
				renderer2.sprite = (Sprite)sprites [sek2];

			}
			renderer.sprite = (Sprite)sprites [sek1floor];
		}
	}
}
