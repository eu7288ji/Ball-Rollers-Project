using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

//	public static GameControl control;

	public float health;


//	void Awake () {
//		if (control == null) 
//		{
//			DontDestroyOnLoad (gameObject);	
//			control = this;
//		} 
//		else if (control != this) 
//		{
//			Destroy (gameObject);
//		}

//	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 40, 100, 30), "Health: " + health);
	}

//	public void Save(){
//		BinaryFormatter game = new BinaryFormatter ();
//		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

//		PlayerData data = new PlayerData ();
//		data.health = health;

//		game.Serialize (file, data); //writes container to save file
//		file.Close ();
//	}

//	public void Load (){
//		if (File.Exists (Application.persistentDataPath + "/playerInfro.dat")) {
//			BinaryFormatter game = new BinaryFormatter ();
//			FileStream file = File.Open (Application.persistentDataPath + "/playerInfro.dat", FileMode.Open);
//			PlayerData data = (PlayerData)game.Deserialize (File);
//			file.Close ();

//			health = data.health;
//		}
//	}
}

//[Serializable] //can now write class to a file
//class PlayerData //data container for saving health
//{
//	public float health;
//}
