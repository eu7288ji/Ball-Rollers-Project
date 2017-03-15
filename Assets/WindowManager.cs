using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {

	public GameObject scoreBoard;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			scoreBoard.SetActive (!scoreBoard.activeSelf);
		}
	}
}
