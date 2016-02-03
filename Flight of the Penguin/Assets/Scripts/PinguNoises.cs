using UnityEngine;
using System.Collections;

public class PinguNoises : MonoBehaviour {
	public AudioClip[] noises;
	GameObject player ;
	float Fuel;
	public float occurrence;
	bool makeSound=false;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
		Fuel = player.GetComponent<Movement> ().Fuel;
		float chance = Random.Range (0.0f, 1.0f);
		if (player.rigidbody2D.velocity.x == 0 && player.rigidbody2D.velocity.y == 0) {
			makeSound = true;
		}
		if (Input.GetButtonDown ("Fire1") && makeSound && Fuel > 0) {
			//if (chance < occurrence){
			if (!audio.isPlaying) {
				var noRepeat = FilterCurrentClip ();
				int random = Random.Range (0, noRepeat.Length);
				audio.clip = noRepeat [random];
				audio.Play ();
				makeSound = false;
			}
			
		} else if (Input.GetButtonDown ("Fire1") && chance < occurrence && Fuel > 0) {
			if (!audio.isPlaying) {
				var noRepeat = FilterCurrentClip ();
				int random = Random.Range (0, noRepeat.Length);
				audio.clip = noRepeat [random];
				audio.Play ();
				//makeSound = false;
			}
		}
	}

	public AudioClip[] FilterCurrentClip()
	{
		var rtrn = new AudioClip[noises.Length - 1];
		var j = 0;
		for(var i  = 0; i < noises.Length; i++)
		{
			if(j >= rtrn.Length)
			{
				return noises;
			}
			if(noises[i] != audio.clip)
			{
				rtrn[j] = noises[i];
				j ++;
			}
		}
		return rtrn;
	}
}
