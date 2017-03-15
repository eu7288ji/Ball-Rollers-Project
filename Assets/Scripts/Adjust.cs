using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust : MonoBehaviour {

	void onGUI()
	{
		if (GUI.Button (new Rect (10, 100, 100, 30), "Health Up")) {
			Respawn.control.health += 10;
		}
		if (GUI.Button (new Rect (10, 140, 100, 30), "Health Down")) {
			Respawn.control.health -= 10;
		}
		if (GUI.Button (new Rect (0, 500, 100, 30), "Save")) {
			Respawn.control.Save();
		}
		if (GUI.Button (new Rect (10, 300, 100, 30), "Load")) {
			Respawn.control.Load();
		}
	}
}
//was initially going to create buttons through here, but had some issues attaching them to the camera