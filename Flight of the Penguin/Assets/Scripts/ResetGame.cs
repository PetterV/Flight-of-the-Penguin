using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {

	public void ResetSaves()
	{
		
		GameControl.control.Reset ();
		
		
	}
}
