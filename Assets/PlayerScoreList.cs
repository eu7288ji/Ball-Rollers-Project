using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	int lastChangeCounter;

	void Start () {

		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();

		lastChangeCounter = scoreManager.GetChangeCounter();

		scoreManager.ChangeScore ("cjball", "tries", 1);
	}
	
	void Update () {
	
		if (scoreManager == null) {
			Debug.LogError ("Forgot to add score manager to object.");
			return;
		}

		if (scoreManager.GetChangeCounter () == lastChangeCounter) {
			return; //no change after update
		}

		lastChangeCounter = scoreManager.GetChangeCounter ();

		while (this.transform.childCount > 0) {
			Transform c = this.transform.GetChild (0);
			c.SetParent (null);
			Destroy (c.gameObject);
		}

		string[] names = scoreManager.GetPlayerNames ("time");

		foreach (string name in names) {
			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("Username").GetComponent<Text> ().text = name;
			go.transform.Find ("Time").GetComponent<Text> ().text = scoreManager.GetScore(name, "time").ToString();
			go.transform.Find ("Tries").GetComponent<Text> ().text = scoreManager.GetScore(name, "tries").ToString();


			}
		}
	}
