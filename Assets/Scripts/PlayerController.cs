using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; //initializing all variables
	public float time = 3; //timer lasts 3 seconds
	//public Text winText;
	public Text countText;
	public Text timerText;

	public float startTime;
	private bool finished = false;
	private int count;

	private Rigidbody rb;

	void Start () //on start of game
	{
		//startTime = 0;
		startTime = Time.time;
		rb = GetComponent<Rigidbody> ();
		//winText.text = ""; //blank until won
	}

	void Update(){
		if (finished)
			return;

		float t = Time.time - startTime; //setting up time

		string minutes = ((int)t / 60).ToString(); //display counter by minutes
		string seconds = (t % 60).ToString ("f2"); //and millisecond value for f2

		timerText.text = minutes + ":" + seconds;
	}


	void FixedUpdate () //constant update when player model is effected
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); //allows player to move on X and Y axis
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed); //adds friction to ball to allow speed increase/decrease
	}
		
	void OnTriggerEnter(Collider other) //when player hits trigger object
	{
		if (other.gameObject.CompareTag ("Player")) //when player hits game object tagged to "Player"
		{
			//winText.text = "You win!"; //triggers win text
			//Destroy (winText, time); //after 3 seconds, removes win text
			count = 0; //resets count back to 0
			setCountText (); //calls try count display
			transform.position = new Vector3 (0, 1, -24); //on win, resets player back to initial spawn

			finished = true; //ends timer on trigger
			timerText.color = Color.yellow; //end timer result turns yellow

			Application.LoadLevel (Application.loadedLevel); //resets the application to current level start
		}
	}

	void setCountText () //method to display try text
	{
		countText.text = "Tries: " + count.ToString ();
	}
		
}

//Some code adapted and altered from original Ball Roll Unity tutorial 