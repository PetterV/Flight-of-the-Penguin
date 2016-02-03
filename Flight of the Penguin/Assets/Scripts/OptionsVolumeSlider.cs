using UnityEngine;
using System.Collections;

public class OptionsVolumeSlider : MonoBehaviour {
	public float sliderValue = 50.0F;
	public GUIStyle backgroundStyle;
	public GUIStyle thumbStyle;


	void Start()
	{
		sliderValue = GameControl.control.soundVolume;
	}

	void OnGUI(){

		sliderValue=GUI.HorizontalSlider (new Rect (200, 300, 100, 30), sliderValue,0.0f, 100.0f, backgroundStyle, thumbStyle);


		GameControl.control.soundVolume = sliderValue;

	}

}