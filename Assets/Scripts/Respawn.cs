using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Respawn : MonoBehaviour 
{
	public static Respawn control;

	public float threshold; //setting all variables
	public Text countText;

	public float health;
	int damage = 10; //damage takes 10 off health each time

	public int count;

	void OnGUI()
	{
		GUI.Label(new Rect(10, 40, 100, 30), "Health: " + health); //GUI text to indicate health
	}

	//void Awake () { //for multiple scenes dealing with persistant data, allows only one instance of gameObject to exist
		//if (control == null) 
		//{
		//	DontDestroyOnLoad (gameObject);	
		//	control = this;
		//} 
		//else if (control != this) 
		//{
		//	Destroy (gameObject);
		//}

	//}

	void Start () //all start funtionality
	{
		
		setCountText (); //calling try display on start to 0
	}

		void FixedUpdate () 
	{
		if (transform.position.y < threshold) //if the ball falls off course
		{
			transform.position = new Vector3 (0, 1, -24); //reset to location of initial spawn
			count = count + 1; //try count goes up 1 each time
			setCountText (); //calling try to display increase
			health -= damage; //for every time player falls below position, reset and lose 10 health

		}

		if (health == 0) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void setCountText () //method for displaying try count 
	{
		countText.text = "Tries: " + count.ToString ();
	}

	public void Save(){
		BinaryFormatter game = new BinaryFormatter (); //what writes to path
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat"); //path set for save data

		PlayerData data = new PlayerData ();
		data.health = health; //saves local variable data
		//data.startTime = startTime;

		game.Serialize (file, data); //writes container to save file
		file.Close ();
	}

	public void Load (){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) { //checks to see if data file exists in specified location
			BinaryFormatter game = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)game.Deserialize (file);
			file.Close ();

			health = data.health; //loads same variable data as last saved
		}
	}

	public void Restart(){ //restart level anytime
		Application.LoadLevel (Application.loadedLevel);
	}

}

[Serializable] //can now write class to a file
class PlayerData //data container for saving health (or theoretically any aspect of the game)
{
	public float health;
}

//Some code adapted and altered from original Ball Roll Unity & Data Persistence tutorial