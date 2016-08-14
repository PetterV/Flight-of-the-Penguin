using UnityEngine;
using System.Collections;

public class FrameRateFixing : MonoBehaviour {

	public int frameRateLock = 60;

	void Awake() {
		Application.targetFrameRate = frameRateLock;
	}
}