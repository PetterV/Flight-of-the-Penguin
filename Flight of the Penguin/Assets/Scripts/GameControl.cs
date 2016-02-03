using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
	public int level= 2;
	public bool level1 = false;
	public int deathCounter;
	public bool collectable;
	public static GameControl control;
	public bool mute = false;
	public float soundVolume = 100.0f;
	PlayerData playerData;
	AudioListener audio = new AudioListener();

	// Use this for initialization
	void Awake() {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
	
		} else if (control != this) {
			Destroy(gameObject);
		}

//
//		if (PlayerPrefs.GetInt ("FullScreen") < 1) {
//			Screen.fullScreen = true;
//		} else
//			Screen.fullScreen = false;

		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			playerData = (PlayerData)bf.Deserialize(file);
			file.Close();
			
			level1 = playerData.getlevel(level);
			collectable = playerData.getCollectable(level);


			if(PlayerPrefs.HasKey("Mute"))
			{
				if(PlayerPrefs.GetInt("Mute")>0)
					mute = true;
				else
					mute = false;
				
			}

			if(PlayerPrefs.HasKey("soundVolume"))
			{
				soundVolume = PlayerPrefs.GetInt("soundVolume");
			}

		}
	}

	void Start()
	{
		audio = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioListener> ();
	}
	
	public bool CheckLevelClear(int levelNumber)
	{
		return(playerData.getlevel (levelNumber));
	}

	public bool CheckCollectable(int levelNumber)
	{
		return(playerData.getCollectable (levelNumber));
	}
	public int getDeath()
	{
		return(playerData.getDeath ());
	}
	
//	void OnGUI()
//	{
//		{
//			if (GUI.Button (new Rect (10, 100, 100, 40), "Collect")) {
//				level1 = true;
//			}
//			if (GUI.Button (new Rect (10, 60, 100, 40), "Update")) {
//				level1 = level1;
//				collectable = collectable;
//			}
//			if (GUI.Button (new Rect (10, 140, 100, 40), "Save")) {
//				BinaryFormatter bf = new BinaryFormatter();
//				PlayerData data = new PlayerData();
//				print ("0");
//
//				if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//				{
//
//					FileStream filed = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
//					data = (PlayerData)bf.Deserialize(filed);
//					filed.Close();
//					
//
//				}
//
//
//				FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
//
//				data.Start();
//
//				data.setlevel(level, level1);
//				print ("Saved");
//				bf.Serialize(file, data);
//				print (level1);
//				file.Close();
//			}
//			else if (GUI.Button (new Rect (10, 180, 100, 40), "Load")) {
//				if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//				{
//					BinaryFormatter bf = new BinaryFormatter();
//					FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
//					PlayerData data = (PlayerData)bf.Deserialize(file);
//					playerData = data;
//					file.Close();
//
//					level1 = data.getlevel(level);
//					collectable = data.getCollectable(level);
//				}
//			} 
//			else if (GUI.Button (new Rect (10, 220, 100, 40), "Reset")) {
//				if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//				{
//					BinaryFormatter bf = new BinaryFormatter();
//					PlayerData data = new PlayerData();
//					print ("0");
//					FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
//					
//					data.Start();
//					
//					data.Reset();
//					print ("Reset");
//					bf.Serialize(file, data);
//					print (level1);
//					file.Close();
//				}
//			}
//		}
//	}
	// Update is called once per frame
	void Update () {
		if(audio) //dont do this every frame. make a function call from options colume slider?
			audio.audio.volume = soundVolume/100;
		else
			audio = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioListener> (); // getting the audiosource from the new camera in the newly loaded level
	}

	public void Reset()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			PlayerData data = new PlayerData();
			print ("0");
			FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
			
			data.Start();
			
			data.Reset();

			print ("Reset");
			bf.Serialize(file, data);
			playerData = data;
			print (level1);
			file.Close();
		}
	}
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			playerData = data;
			file.Close();
			
			level1 = data.getlevel(level);
			collectable = data.getCollectable(level);
		}
	} 


	public void LevelClear(int levelNumber, bool collected){
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		print ("0");
		
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			
			FileStream filed = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			data = (PlayerData)bf.Deserialize(filed);

			filed.Close();
			
			
		}
		
		
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		
		data.Start();
		
		data.setlevel(levelNumber, true, collected);
		print ("LevelClear");
		bf.Serialize(file, data);
		print (collected);
		playerData = data;
		file.Close();
	}
	public void Death()
	{
		deathCounter++;
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		print ("0");
		
		
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		
		data.Start();
		data.setlevel(level, level1);
		bf.Serialize(file, data);
		playerData = (PlayerData)bf.Deserialize(file);
		file.Close();
		
	}
	public bool checkCollectable(int levelNumber)
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			playerData =data;
			file.Close();
			
			return (data.getCollectable(levelNumber));
		}
		return false;
	}
	void OnDestroy()
	{
		int i = (int) Mathf.Floor(soundVolume);
		PlayerPrefs.SetInt("soundVolume",i);
	}
	void OnApplicationQuit()
	{
		int i = (int) Mathf.Floor(soundVolume);
		PlayerPrefs.SetInt("soundVolume",i);
	}
}
[Serializable]
class PlayerData
{
	List <bool> level = new List<bool>();
	List <bool> collect = new List<bool>();
	List <bool> challenge = new List<bool>();
	public int deathCounter;

	public void Start(){
		//check if it exists 
		if (level.Count < 150) {
			Debug.Log("OVER");
			int times = 200;
			for (int i = 0; i<times; i++)
				level.Add (false);

			for (int i = 0; i<times; i++)
				collect.Add (false);

			for (int i = 0; i<times; i++)
				challenge.Add (false);
		}
	}

	public void Reset ()
	{
		deathCounter = 0;
		if (level.Count < 150) {
			int times = 200;
			for (int i = 0; i<times; i++)
				level[i] =(false);
		
			for (int i = 0; i<times; i++)
				collect[i]= (false);
		
			for (int i = 0; i<times; i++)
				challenge[i] =(false);
		}
	}


	public void setlevel(int levelNumber, bool boolean){
		Debug.Log ("SETINGLEVEL");
		Debug.Log (levelNumber);
		Debug.Log (boolean);
		level[levelNumber] = boolean;
	}
	public void setlevel(int levelNumber, bool boolean, bool collectable){
		Debug.Log ("SETINGLEVEL");
		Debug.Log (levelNumber);
		Debug.Log (boolean);
		Debug.Log ("Collected " + collectable);
		level[levelNumber] = boolean;
		collect [levelNumber] = collectable;
	}
	public bool getlevel(int levelNumber){
		Debug.Log (levelNumber);
		Debug.Log (level);
		
		return level[levelNumber];
	}

	public bool getCollectable(int levelNumber)
	{
		Debug.Log ("GetCollectable");
		Debug.Log (collect[levelNumber]);
		return(collect [levelNumber]);
	}
	public int getDeath()
	{
		return deathCounter;
	}
	public void Death()
	{
		deathCounter++;
	}


}