using UnityEngine;
using System.Collections;

public class ButtonSceneChange : MonoBehaviour {

	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);

	}
}
