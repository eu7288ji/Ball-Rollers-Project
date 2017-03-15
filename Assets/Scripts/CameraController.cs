using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player; //initialize player

	private Vector3 offset; //for camera


	//public static T instance == null; 
	//void Awake() 
	//{ 
		//if (instance == null) instance = this; else Destroy (transform.gameObject); DontDestroyOnLoad (transform.gameObject); }

	void Start () {
		offset = transform.position - player.transform.position; //sets camera to specific position
		
	}

	void LateUpdate () //updates once per frame 
	{
		transform.position = player.transform.position + offset; //moves camera with player movement
		
	}
}

//Some code adapted and altered from original Ball Roll Unity tutorial