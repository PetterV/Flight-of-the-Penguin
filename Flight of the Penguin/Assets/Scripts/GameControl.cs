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
	public float levelTime;
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
			playerData.Start();
			level1 = playerData.getlevel(level);
			collectable = playerData.getCollectable(level);
			levelTime = playerData.getLevelTime(level);


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
		else {
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
			
			data.setlevel(level, level1);
		//	print ("Saved");
			bf.Serialize(file, data);
			print (level1);
			file.Close();
		}
	}

	void Start()
	{
		audio = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioListener> ();//works when changing level
		GameObject.FindWithTag("GameMusic").GetComponent<Persistence>().ReturnMusic();
	}
	
	public bool CheckLevelClear(int levelNumber)
	{
		return(playerData.getlevel (levelNumber));
	}

	public bool CheckLevelNumberClear(int neededLevels) //needed levels that needs to be cleared to be allowed to enter the level
	{
		if (playerData.getLevelsCleared() > neededLevels)
			return true;
		return false;
	}

	public bool CheckCollectable(int levelNumber)
	{
		return(playerData.getCollectable (levelNumber));
	}
	public float CheckLevelTime(int levelNumber)
	{
		return(playerData.getLevelTime(levelNumber));
	}
	public int getDeath()
	{
		return(playerData.getDeath ());
	}

	void OnGUI()
	{
		{
			if (GUI.Button (new Rect (10, 100, 100, 40), "Collect")) {
				level1 = true;
			}
			if (GUI.Button (new Rect (10, 60, 100, 40), "Update")) {
				level1 = level1;
				collectable = collectable;
				levelTime = levelTime;
			}
			if (GUI.Button (new Rect (10, 140, 100, 40), "Save")) {
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

				data.setlevel(level, level1);
				print ("Saved");
				bf.Serialize(file, data);
				print (level1);
				file.Close();
			}
			else if (GUI.Button (new Rect (10, 180, 100, 40), "Load")) {
				if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
				{
					BinaryFormatter bf = new BinaryFormatter();
					FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
					PlayerData data = (PlayerData)bf.Deserialize(file);
					playerData = data;
					file.Close();

					level1 = data.getlevel(level);
					collectable = data.getCollectable(level);
					levelTime = data.getLevelTime(level);
				}
			} 
			else if (GUI.Button (new Rect (10, 220, 100, 40), "Reset")) {
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
					print (level1);
					file.Close();
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if(audio) //dont do this every frame. make a function call from options volume slider?
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
			levelTime = data.getLevelTime(level);
		}
	} 


	public void LevelClear(int levelNumber, bool collected){
		BinaryFormatter bf = new BinaryFormatter();
		PlayerData data = new PlayerData();
		print ("---------------------------"+Time.timeSinceLevelLoad);
		float currentLevelTime = Time.timeSinceLevelLoad;
		
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			
			FileStream filed = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			data = (PlayerData)bf.Deserialize(filed);

			filed.Close();
			
			
		}
		
		
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		
		data.Start();
		
		data.setlevel(levelNumber, true, collected,currentLevelTime);
		print ("LevelClear");
		print (currentLevelTime);
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
	List <float> timed = new List<float>();//time it took to complete the level in seconds
	public int deathCounter;

	public void Start(){
		//check if it exists 
		Debug.Log (",,,,,,,,,,,,,,,,,,,,,,,,,");
		if (level.Count < 150) {
			Debug.Log("OVER");
			int times = 200;
			for (int i = 0; i<times; i++)
				level.Add (false);

			for (int i = 0; i<times; i++)
				collect.Add (false);

			for (int i = 0; i<times; i++)
				challenge.Add (false);

			for (int i = 0; i<times; i++)
				timed.Add (0);
		}
	}

	public void Reset ()
	{
		deathCounter = 0;

			int times = 200;
			for (int i = 0; i<times; i++)
				level[i] =(false);
		
			for (int i = 0; i<times; i++)
				collect[i]= (false);
		
			for (int i = 0; i<times; i++)
				challenge[i] =(false);

			for (int i = 0; i<200; i++)
				timed [i] = 0;

	}
	
	public void setlevel(int levelNumber, bool boolean){
		Debug.Log ("SETINGLEVEL");
		Debug.Log (levelNumber);
		Debug.Log (boolean);
		level[levelNumber] = boolean;
	}
	public void setlevel(int levelNumber, bool boolean, bool collectable, float currLevelTime){
		Debug.Log ("SETINGLEVEL");
		Debug.Log (levelNumber);
		Debug.Log (boolean);
		Debug.Log ("Collected " + collectable);
		level[levelNumber] = boolean;
		collect [levelNumber] = collectable;
		if(timed[levelNumber] > currLevelTime || timed[levelNumber] == 0)
			timed [levelNumber] = currLevelTime;
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
	public float getLevelTime(int levelNumber)
	{
		Debug.Log (levelNumber);
		if (timed.Count==null) {
			for (int i = 0; i<200; i++)
				timed.Add (0);
			Debug.Log(".............................................");
		}
		Debug.Log (timed.Count);
		Debug.Log ("GetLevelTime");
		Debug.Log (timed[levelNumber]);
		return(timed [levelNumber]);
	}

	public int getLevelsCleared()
	{
		int levelCleared = 0;
		foreach (bool clear in level)
			if (clear)
				levelCleared++;
		return levelCleared;
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