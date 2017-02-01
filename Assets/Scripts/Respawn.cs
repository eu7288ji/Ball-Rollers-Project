using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Respawn : MonoBehaviour 
{
	public float threshold; //setting all variables
	public Text countText;

	private int count;

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
		}
	}

	void setCountText () //method for displaying try count 
	{
		countText.text = "Tries: " + count.ToString ();
	}
}

//Some code adapted and altered from original Ball Roll Unity tutorial